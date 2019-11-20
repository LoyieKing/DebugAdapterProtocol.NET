using DebugAdapterProtocol.Protocol.BaseProtocol;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DebugAdapterProtocol.Server
{
    internal class MessageSender
    {
        private Stream outputStream;
        private JsonSerializerSettings jsonSerializerSettings;
        private long seq;
        public MessageSender(Stream outputStream)
        {
            this.outputStream = outputStream;

            jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            seq = 1;
        }

        public void SendMessage(ProtocolMessage message)
        {
            message.Sequence = seq++;
            var bytes = ConvertToBytes(message);
            outputStream.Write(bytes, 0, bytes.Length);
        }

        private byte[] ConvertToBytes(ProtocolMessage request)
        {


            var asJson = JsonConvert.SerializeObject(request,jsonSerializerSettings);

            byte[] jsonBytes = Encoding.UTF8.GetBytes(asJson);
            string header = string.Format("Content-Length: {0}{1}", jsonBytes.Length, "\r\n\r\n");
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);

            byte[] data = new byte[headerBytes.Length + jsonBytes.Length];
            System.Buffer.BlockCopy(headerBytes, 0, data, 0, headerBytes.Length);
            System.Buffer.BlockCopy(jsonBytes, 0, data, headerBytes.Length, jsonBytes.Length);

            return data;
        }
    }
}
