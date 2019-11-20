using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that some information about a module has changed.</para>
    /// </summary>
    public class ModuleEvent : BaseProtocol.Event<ModuleEvent.ModuleEventBody>
    {
        public class ModuleEventBody
        {
            /// <summary>
            /// <para>The reason for the event.</para>
            /// </summary>
            public EventReason Reason { get; }
            /// <summary>
            /// <para>The new, changed, or removed module. In case of 'removed' only the module id is used.</para>
            /// </summary>
            public Module Module { get; }
            public ModuleEventBody(EventReason reason, Module module)
            {
                Reason = reason;
                Module = module;
            }
        }
        public ModuleEvent(ModuleEventBody body)
            : base("module", body)
        {
        }
    }
}
