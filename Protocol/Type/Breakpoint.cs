namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Information about a Breakpoint created in setBreakpoints or setFunctionBreakpoints.</para>
    /// </summary>
    public class Breakpoint
    {
        /// <summary>
        /// <para>An optional identifier for the breakpoint. It is needed if breakpoint events are used to update or remove breakpoints.</para>
        /// </summary>
        public long? Id { get; }
        /// <summary>
        /// <para>If true breakpoint could be set (but not necessarily at the desired location).</para>
        /// </summary>
        public bool Verified { get; }
        /// <summary>
        /// <para>An optional message about the state of the breakpoint. This is shown to the user and can be used to explain why a breakpoint could not be verified.</para>
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// <para>The source where the breakpoint is located.</para>
        /// </summary>
        public Source Source { get; }
        /// <summary>
        /// <para>The start line of the actual range covered by the breakpoint.</para>
        /// </summary>
        public int? Line { get; }
        /// <summary>
        /// <para>An optional start column of the actual range covered by the breakpoint.</para>
        /// </summary>
        public int? Column { get; }
        /// <summary>
        /// <para>An optional end line of the actual range covered by the breakpoint.</para>
        /// </summary>
        public int? EndLine { get; }
        /// <summary>
        /// <para>An optional end column of the actual range covered by the breakpoint. If no end line is given, then the end column is assumed to be in the start line.</para>
        /// </summary>
        public int? EndColumn { get; }
        public Breakpoint(
            bool verified,
            string message = null,
            Source source = null,
            long? id = null,
            int? line = null,
            int? column = null,
            int? endLine = null,
            int? endColumn = null)
        {
            Id = id;
            Verified = verified;
            Message = message;
            Source = source;
            Line = line;
            Column = column;
            EndLine = endLine;
            EndColumn = endColumn;
        }
    }
}
