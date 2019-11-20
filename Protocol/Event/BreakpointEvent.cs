using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that some information about a breakpoint has changed.</para>
    /// </summary>
    public class BreakpointEvent : BaseProtocol.Event<BreakpointEvent.BreakpointEventBody>
    {
        public class BreakpointEventBody
        {
            /// <summary>
            /// <para>The reason for the event.</para>
            /// <para>Values: 'changed', 'new', 'removed', etc.</para>
            /// </summary>
            public EventReason Reason { get; }
            /// <summary>
            /// <para>The 'id' attribute is used to find the target breakpoint and the other attributes are used as the new values.</para>
            /// </summary>
            public Breakpoint Breakpoint { get; }
            public BreakpointEventBody(EventReason reason, Breakpoint breakpoint)
            {
                Reason = reason;
                Breakpoint = breakpoint;
            }
        }
        public BreakpointEvent(BreakpointEventBody body)
            : base("breakpoint", body)
        {
        }
    }
}
