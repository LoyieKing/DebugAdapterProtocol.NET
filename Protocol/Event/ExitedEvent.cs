namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that the debuggee has exited and returns its exit code.</para>
    /// </summary>
    public class ExitedEvent : BaseProtocol.Event<ExitedEvent.ExitedEventBody>
    {
        public class ExitedEventBody
        {
            /// <summary>
            /// <para>The exit code returned from the debuggee.</para>
            /// </summary>
            public long ExitCode { get; }
            public ExitedEventBody(long exitCode)
            {
                ExitCode = exitCode;
            }
        }
        public ExitedEvent(ExitedEventBody body)
            : base("exited", body)
        {
        }
    }

}
