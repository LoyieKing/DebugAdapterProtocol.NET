using Newtonsoft.Json;

namespace DebugAdapterProtocol.Protocol.BaseProtocol
{
    /// <summary>
    /// A debug adapter initiated event.
    /// </summary>
    public class Event : ProtocolMessage
    {
        /// <summary>
        /// Type of event.
        /// </summary>
        [JsonProperty("event")]
        public string EventType { get; }

        [JsonIgnore]
        public virtual bool HasBody => false;
        public Event(string @event)
        : base("event")
        {
            EventType = @event;
        }
    }

    /// <summary>
    /// A debug adapter initiated event.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Event<T> : Event
    {
        /// <summary>
        /// Event-specific information.
        /// </summary>
        public T Body { get; }

        [JsonIgnore]
        public override bool HasBody => true;

        public Event(string @event, T body)
            : base(@event)
        {
            this.Body = body;
        }
    }
}
