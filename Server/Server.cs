using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Event;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace DebugAdapterProtocol.Server
{
    public class ProtocolServer
    {
        public delegate void ProtocolMessageDelegate<T>(ProtocolServer server, T request) where T : ProtocolMessage;

        private Stream inputStream;
        private Stream outputStream;

        private MessageReceiver messageReceiver;
        private MessageSender messageSender;

        private Dictionary<Type, Action<ProtocolMessage>> registeredMessage;

        private TaskCompletionSource<bool> taskCompletion;

        public ProtocolServer(Stream inputStream, Stream outputStream)
        {
            this.inputStream = inputStream;
            this.outputStream = outputStream;

            messageReceiver = new MessageReceiver(inputStream);
            messageSender = new MessageSender(outputStream);

            registeredMessage = new Dictionary<Type, Action<ProtocolMessage>>();

            messageReceiver.MessageReceived += MessageReceiver_MessageReceived;

        }


        public ProtocolServer RegisterProtocolMessage<T>(ProtocolMessageDelegate<T> action)
            where T : ProtocolMessage
        {
            if (registeredMessage.ContainsKey(typeof(T)))
            {
                throw new Exception("Event has already registered!");
            }
            registeredMessage.Add(typeof(T), new Action<ProtocolMessage>((e) => { action(this, (T)e); }));

            return this;
        }

        public void RegisterProtocolMessageOnce<T>(ProtocolMessageDelegate<T> action)
            where T : ProtocolMessage
        {
            if (registeredMessage.ContainsKey(typeof(T)))
            {
                var preMessage = registeredMessage[typeof(T)];
                var onceMessage = new Action<ProtocolMessage>((e) =>
                {
                    action(this, (T)e);
                    registeredMessage[typeof(T)] = preMessage;
                });
                registeredMessage.Add(typeof(T), onceMessage);
            }
            else
            {
                registeredMessage.Add(typeof(T), new Action<ProtocolMessage>((e) =>
                {
                    action(this, (T)e);
                    registeredMessage.Remove(typeof(T));
                }));
            }
        }

        public bool QueryRegisteredProtocolMessage<T>()
        {
            return registeredMessage.ContainsKey(typeof(T));
        }

        public bool UnregisterProtocolMessage<T>()
        {
            return registeredMessage.Remove(typeof(T));
        }

        public Task Start()
        {
            taskCompletion = new TaskCompletionSource<bool>();
            messageReceiver.Start();
            return taskCompletion.Task;
        }

        public void Stop()
        {
            messageReceiver.Stop();
            registeredMessage.Clear();
            messageReceiver.MessageReceived -= MessageReceiver_MessageReceived;

            taskCompletion.SetResult(true);
        }

        public void SendMessage(ProtocolMessage message)
        {
            messageSender.SendMessage(message);
            if (message.GetType() != typeof(OutputEvent))
                Debug.WriteLine("Send Message:" + message.ToString(), "ProtocolServer.Debug");
        }

        private void MessageReceiver_MessageReceived(ProtocolMessage message)
        {
            var type = message.GetType();
            Debug.WriteLine("Receive Message:" + type, "ProtocolServer.Debug");
            if (registeredMessage.ContainsKey(type))
                registeredMessage[type].Invoke(message);
        }


    }
}
