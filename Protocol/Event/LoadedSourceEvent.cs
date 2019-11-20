using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that some source has been added, changed, or removed from the set of all loaded sources.</para>
    /// </summary>
    public class LoadedSourceEvent : BaseProtocol.Event<LoadedSourceEvent.LoadedSourceEventBody>
    {
        public class LoadedSourceEventBody
        {
            /// <summary>
            /// <para>The reason for the event.</para>
            /// </summary>
            public EventReason Reason { get; }
            /// <summary>
            /// <para>The new, changed, or removed source.</para>
            /// </summary>
            public Source Source { get; }
            public LoadedSourceEventBody(EventReason reason, Source source)
            {
                Reason = reason;
                Source = source;
            }
        }
        public LoadedSourceEvent(LoadedSourceEventBody body)
            : base("loadedSource", body)
        {
        }
    }
}
