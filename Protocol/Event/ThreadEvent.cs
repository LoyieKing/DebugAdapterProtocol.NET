namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that a thread has started or exited.</para>
    /// </summary>
    public class ThreadEvent : BaseProtocol.Event<ThreadEvent.ThreadEventBody>
    {
        public class ThreadEventBody
        {
            /// <summary>
            /// <para>The reason for the event.</para>
            /// <para>Values: 'started', 'exited', etc.</para>
            /// </summary>
            public string Reason { get; }
            /// <summary>
            /// <para>The identifier of the thread.</para>
            /// </summary>
            public long ThreadId { get; }
            public ThreadEventBody(string reason, long threadId)
            {
                Reason = reason;
                ThreadId = threadId;
            }
        }
        public ThreadEvent(ThreadEventBody body)
            : base("thread", body)
        {
        }
    }

}
