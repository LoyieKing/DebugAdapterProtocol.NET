using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Event;
using DebugAdapterProtocol.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DebugAdapterProtocol.Serialization
{
    class ProtocolJsonConverter : JsonConverter
    {
        private Assembly executingAssembly;

        private Dictionary<string, Type> eventDictionary;
        private Dictionary<string, Type> requestDictionary;
        private Dictionary<string, Type> responseDictionary;


        public ProtocolJsonConverter()
        {
            executingAssembly = Assembly.GetExecutingAssembly();

            eventDictionary = new Dictionary<string, Type>(12);
            requestDictionary = new Dictionary<string, Type>(40);
            responseDictionary = new Dictionary<string, Type>(40);

            foreach (var type in executingAssembly.GetTypes())
            {
                string name = null;
                Type baseType = type.BaseType;
                if (baseType == null)
                    continue;
                switch (type.Namespace)
                {
                    case "DebugAdapterProtocol.Protocol.Event":
                        if (baseType == typeof(Event) || (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(Event<>)))
                        {
                            name = ClassNameParser.Parse(type.Name, "Event");
                            if (name != null)
                            {
                                eventDictionary.Add(name, type);
                            }
                        }
                        break;
                    case "DebugAdapterProtocol.Protocol.Request":
                    case "DebugAdapterProtocol.Protocol.ReverseRequest":
                        if (baseType == typeof(Request) || (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(Request<>)))
                        {
                            name = ClassNameParser.Parse(type.Name, "Request");
                            if (name != null)
                            {
                                requestDictionary.Add(name, type);
                            }
                        }
                        else if (baseType == typeof(Response) || (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(Response<>)))
                        {
                            name = ClassNameParser.Parse(type.Name, "Response");
                            if (name != null)
                            {
                                responseDictionary.Add(name, type);
                            }
                        }
                        break;

                }
            }


            
        }


        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            if (objectType.Assembly != executingAssembly)
                return false;
            if (!objectType.Namespace.StartsWith("DebugAdapterProtocol.Protocol"))
                return false;
            return true;
        }


        private ProtocolMessage ReadProtocolMessage(JObject jObject)
        {
            var seq = jObject.Value<long>("seq");
            var type = jObject.Value<string>("type");

            ProtocolMessage result = null;
            switch (type)
            {
                case "event": result = ReadEvent(jObject); break;
                case "request": result = ReadRequest(jObject); break;
                case "response": result = ReadResponse(jObject); break;
                default: throw new NotImplementedException();// TODO: Parser to unknown request class
            }
            result.Sequence = seq;

            return result;
        }

        private Event ReadEvent(JObject jObject)
        {
            var eventType = jObject.Value<string>("event");
            var type = eventDictionary[eventType];
            if (type.BaseType == typeof(Event))
            {
                return (Event)type
                    .GetConstructor(new Type[0])
                    .Invoke(new object[0]);
            }

            var innerType = type.BaseType.GetGenericArguments()[0];
            object innerValue = null;

            if (jObject.ContainsKey("body"))
            {
                innerValue = jObject.Value(innerType, "body");
            }

            return (Event)type
                .GetConstructor(new Type[] { innerType })
                .Invoke(new object[] { innerValue });
        }

        private Request ReadRequest(JObject jObject)
        {
            var eventType = jObject.Value<string>("command");
            var type = requestDictionary[eventType];
            if (type.BaseType == typeof(Request))
            {
                return (Request)type
                    .GetConstructor(new Type[0])
                    .Invoke(new object[0]);
            }

            var innerType = type.BaseType.GetGenericArguments()[0];
            object innerValue = null;

            if (jObject.ContainsKey("arguments"))
            {
                innerValue = jObject.Value(innerType, "arguments");
            }

            return (Request)type
                .GetConstructor(new Type[] { innerType })
                .Invoke(new object[] { innerValue });
        }

        // May never user
        private Response ReadResponse(JObject jObject)
        {
            var eventType = jObject.Value<string>("command");
            var request_seq = jObject.Value<long>("request_seq");
            var success = jObject.Value<bool>("success");
            string message = null;
            if (jObject.ContainsKey("message"))
                message = jObject.Value<string>("message");


            var type = responseDictionary[eventType];
            if (type.BaseType == typeof(Response))
            {
                return (Response)type
                    .GetConstructor(new Type[] { typeof(long), typeof(bool), typeof(string) })
                    .Invoke(new object[] { request_seq, success, message });
            }

            var innerType = type.BaseType.GetGenericArguments()[0];
            object innerValue = null;

            if (jObject.ContainsKey("body"))
            {
                innerValue = jObject.Value(innerType, "body");
            }

            return (Response)type
                .GetConstructor(new Type[] { typeof(long), typeof(bool), innerType, typeof(string) })
                .Invoke(new object[] { request_seq, success, innerValue, message });




        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobj = serializer.Deserialize<JObject>(reader);
            return ReadProtocolMessage(jobj);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
