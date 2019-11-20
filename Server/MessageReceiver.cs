using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Serialization;
using DebugAdapterProtocol.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DebugAdapterProtocol.Server
{
    internal class MessageReceiver
    {

        private Stream inputStream;

        private JsonSerializerSettings JsonSerializerSettings;

        public const char CR = '\r';
        public const char LF = '\n';
        public static char[] CRLF = { CR, LF };
        public static char[] HeaderKeys = { CR, LF, ':' };
        public const short MinBuffer = 21; // Minimum size of the buffer "Content-Length: X\r\n\r\n"

        private bool running;
        private Thread inputThread;

        public MessageReceiver(Stream inputStream)
        {
            this.inputStream = inputStream;
            inputThread = new Thread(ProcessInputStream) { IsBackground = true, Name = "ProcessInputStream" };

            JsonSerializerSettings = new JsonSerializerSettings();
            JsonSerializerSettings.Converters = new List<JsonConverter>() { new ProtocolJsonConverter() };
        }

        public void Start()
        {
            running = true;
            inputThread.Start();
        }

        public void Stop()
        {
            running = false;
        }

        private void ProcessInputStream()
        {
            // header is encoded in ASCII
            // "Content-Length: 0" counts bytes for the following content
            // content is encoded in UTF-8
            while (true)
            {
                if (!running)
                    return;

                try
                {

                    var buffer = new byte[300];
                    var current = inputStream.Read(buffer, 0, MinBuffer);
                    if (current == 0) return; // no more _input
                    while (current < MinBuffer ||
                        buffer[current - 4] != CR || buffer[current - 3] != LF ||
                        buffer[current - 2] != CR || buffer[current - 1] != LF)
                    {
                        var n = inputStream.Read(buffer, current, 1);
                        if (n == 0) return; // no more _input, mitigates endless loop here.
                        current += n;
                    }

                    var headersContent = System.Text.Encoding.ASCII.GetString(buffer, 0, current);
                    var headers = headersContent.Split(HeaderKeys, StringSplitOptions.RemoveEmptyEntries);
                    long length = 0;
                    for (var i = 1; i < headers.Length; i += 2)
                    {
                        // starting at i = 1 instead of 0 won't throw, if we have uneven headers' length
                        var header = headers[i - 1];
                        var value = headers[i].Trim();
                        if (header.Equals("Content-Length", StringComparison.OrdinalIgnoreCase))
                        {
                            length = 0;
                            long.TryParse(value, out length);
                        }
                    }

                    if (length == 0 || length >= int.MaxValue)
                    {
                        HandleRequest(string.Empty);
                    }
                    else
                    {
                        var requestBuffer = new byte[length];
                        var received = 0;
                        while (received < length)
                        {
                            var n = inputStream.Read(requestBuffer, received, requestBuffer.Length - received);
                            if (n == 0) return; // no more _input
                            received += n;
                        }
                        // TODO sometimes: encoding should be based on the respective header (including the wrong "utf8" value)
                        var payload = System.Text.Encoding.UTF8.GetString(requestBuffer);
                        HandleRequest(payload);
                    }
                }
                catch (IOException)
                {
                    Debug.WriteLine("Input stream has been closed.");
                    return;
                }
            }

        }

        private void HandleRequest(string message)
        {
            var pmsg = JsonConvert.DeserializeObject<ProtocolMessage>(message, JsonSerializerSettings);
            MessageReceived?.Invoke(pmsg);
        }

        public delegate void MessageReceivedHandler(ProtocolMessage message);
        public event MessageReceivedHandler MessageReceived;


    }
}
