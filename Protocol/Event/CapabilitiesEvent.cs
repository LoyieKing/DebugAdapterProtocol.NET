using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that one or more capabilities have changed.</para>
    /// <para>Since the capabilities are dependent on the frontend and its UI, it might not be possible to change that at random times (or too late).</para>
    /// <para>Consequently this event has a hint characteristic: a frontend can only be expected to make a ‘best effort’ in honouring individual capabilities but there are no guarantees.</para>
    /// <para>Only changed capabilities need to be included, all other capabilities keep their values.</para>
    /// </summary>
    public class CapabilitiesEvent : BaseProtocol.Event<CapabilitiesEvent.CapabilitiesEventBody>
    {
        public class CapabilitiesEventBody
        {
            /// <summary>
            /// <para>The set of updated capabilities.</para>
            /// </summary>
            public Capabilities Capabilities { get; }
            public CapabilitiesEventBody(Capabilities capabilities)
            {
                Capabilities = capabilities;
            }
        }
        public CapabilitiesEvent(CapabilitiesEventBody body)
            : base("capabilities", body)
        {
        }
    }
}
