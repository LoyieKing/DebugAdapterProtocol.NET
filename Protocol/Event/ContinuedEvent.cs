namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that the execution of the debuggee has continued.</para>
    /// <para>Please note: a debug adapter is not expected to send this event in response to a request that implies that execution continues, e.g. ‘launch’ or ‘continue’.</para>
    /// <para>It is only necessary to send a ‘continued’ event if there was no previous request that implied this.</para>
    /// </summary>
    public class ContinuedEvent : BaseProtocol.Event<ContinuedEvent.ContinuedEventBody>
    {
        public class ContinuedEventBody
        {
            /// <summary>
            /// <para>The thread which was continued.</para>
            /// </summary>
            public long ThreadId { get; }
            /// <summary>
            /// <para>If 'allThreadsContinued' is true, a debug adapter can announce that all threads have continued.</para>
            /// </summary>
            public bool? AllThreadsContinued { get; }
            public ContinuedEventBody(long threadId, bool? allThreadsContinued = null)
            {
                ThreadId = threadId;
                AllThreadsContinued = allThreadsContinued;
            }
        }
        public ContinuedEvent(ContinuedEventBody body)
            : base("continued", body)
        {
        }
    }

}
