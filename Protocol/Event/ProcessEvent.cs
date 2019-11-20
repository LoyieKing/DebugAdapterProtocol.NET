namespace DebugAdapterProtocol.Protocol.Event
{
    public enum StartMethod
    {
        Launch,
        Attach,
        AttachForSuspendedLaunch
    }

    /// <summary>
    /// <para>The event indicates that the debugger has begun debugging a new process. Either one that it has launched, or one that it has attached to.</para>
    /// </summary>
    public class ProcessEvent : BaseProtocol.Event<ProcessEvent.ProcessEventBody>
    {
        public class ProcessEventBody
        {
            /// <summary>
            /// <para>The logical name of the process. This is usually the full path to process's executable file. Example: /home/example/myproj/program.js.</para>
            /// </summary>
            public string Name { get; }
            /// <summary>
            /// <para>The system process id of the debugged process. This property will be missing for non-system processes.</para>
            /// </summary>
            public long? SystemProcessId { get; }
            /// <summary>
            /// <para>If true, the process is running on the same computer as the debug adapter.</para>
            /// </summary>
            public bool? IsLocalProcess { get; }
            /// <summary>
            /// <para>Describes how the debug engine started debugging this process.</para>
            /// <para>'launch': Process was launched under the debugger.</para>
            /// <para>'attach': Debugger attached to an existing process.</para>
            /// <para>'attachForSuspendedLaunch': A project launcher component has launched a new process in a suspended state and then asked the debugger to attach.</para>
            /// </summary>
            public StartMethod? StartMethod { get; }
            /// <summary>
            /// <para>The size of a pointer or address for this process, in bits. This value may be used by clients when formatting addresses for display.</para>
            /// </summary>
            public long? PointerSize { get; }
            public ProcessEventBody(string name, long? systemProcessId = null, bool? isLocalProcess = null, StartMethod? startMethod = null, long? pointerSize = null)
            {
                Name = name;
                SystemProcessId = systemProcessId;
                IsLocalProcess = isLocalProcess;
                StartMethod = startMethod;
                PointerSize = pointerSize;
            }
        }
        public ProcessEvent(ProcessEventBody body)
            : base("process", body)
        {
        }
    }
}
