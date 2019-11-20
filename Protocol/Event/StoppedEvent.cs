namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that the execution of the debuggee has stopped due to some condition.</para>
    /// <para>This can be caused by a break point previously set, a stepping action has completed, by executing a debugger statement etc.</para>
    /// </summary>
    public class StoppedEvent : BaseProtocol.Event<StoppedEvent.StoppedEventBody>
    {

        public class StoppedEventBody
        {
            /// <summary>
            /// <para>The reason for the event.</para>
            /// <para>For backward compatibility this string is shown in the UI if the 'description' attribute is missing (but it must not be translated).</para>
            /// <para>Values: 'step', 'breakpoint', 'exception', 'pause', 'entry', 'goto', 'function breakpoint', 'data breakpoint', etc.</para>
            /// </summary>
            public string Reason { get; }

            /// <summary>
            /// The full reason for the event, e.g. 'Paused on exception'. This string is shown in the UI as is and must be translated.
            /// </summary>
            public string Description { get; }

            /// <summary>
            /// The thread which was stopped.
            /// </summary>
            public long? ThreadId { get; }

            /// <summary>
            /// A value of true hints to the frontend that this event should not change the focus.
            /// </summary>
            public bool? PreserveFocusHint { get; }

            /// <summary>
            /// Additional information. E.g. if reason is 'exception', text contains the exception name. This string is shown in the UI.
            /// </summary>
            public string Text { get; }

            /// <summary>
            /// <para>If 'allThreadsStopped' is true, a debug adapter can announce that all threads have stopped.</para>
            /// <para>- The client should use this information to enable that all threads can be expanded to access their stacktraces.</para>
            /// <para>- If the attribute is missing or false, only the thread with the given threadId can be expanded.</para>
            /// </summary>
            public bool? AllThreadsStopped { get; }

            public StoppedEventBody(
                string reason,
                string description = null,
                long? threadId = null,
                bool? preserveFocusHint = null,
                string text = null,
                bool? allThreadsStopped = null
                )
            {
                Reason = reason;
                Description = description;
                ThreadId = threadId;
                PreserveFocusHint = preserveFocusHint;
                Text = text;
                AllThreadsStopped = allThreadsStopped;
            }
        }

        public StoppedEvent(StoppedEventBody body)
            : base("stopped", body)
        {

        }

    }
}
