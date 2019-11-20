using System.Collections.Generic;

namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that debugging of the debuggee has terminated. This does not mean that the debuggee itself has exited.</para>
    /// </summary>
    public class TerminatedEvent : BaseProtocol.Event<TerminatedEvent.TerminatedEventBody>
    {
        public class TerminatedEventBody
        {
            /// <summary>
            /// <para>A debug adapter may set 'restart' to true (or to an arbitrary object) to request that the front end restarts the session.</para>
            /// <para>The value is not interpreted by the client and passed unmodified as an attribute '__restart' to the 'launch' and 'attach' requests.</para>
            /// </summary>
            public Dictionary<string, object> Restart { get; }
            public TerminatedEventBody(Dictionary<string, object> restart = null)
            {
                Restart = restart;
            }
        }
        public TerminatedEvent(TerminatedEventBody body = null)
            : base("terminated", body)
        {
        }
    }

}
