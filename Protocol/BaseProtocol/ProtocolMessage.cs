using Newtonsoft.Json;

namespace DebugAdapterProtocol.Protocol.BaseProtocol
{
    /// <summary>
    /// Base class of requests, responses, and events.
    /// </summary>
    public class ProtocolMessage
    {
        /// <summary>
        /// Sequence number (also known as message ID). For protocol messages of type 'request' this ID can be used to cancel the request.
        /// </summary>
        [JsonProperty("seq")]
        public long Sequence { get; internal set; }

        /// <summary>
        /// Message type.
        /// <para>Values: 'request', 'response', 'event', etc.</para>
        /// </summary>
        public string Type { get; }

        public ProtocolMessage(string type)
        {
            Type = type;
        }

    }
}
