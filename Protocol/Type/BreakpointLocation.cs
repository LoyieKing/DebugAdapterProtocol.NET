namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Properties of a breakpoint location returned from the ‘breakpointLocations’ request.</para>
    /// </summary>
    public class BreakpointLocation
    {
        /// <summary>
        /// <para>Start line of breakpoint location.</para>
        /// </summary>
        public long Line { get; }
        /// <summary>
        /// <para>Optional start column of breakpoint location.</para>
        /// </summary>
        public long? Column { get; }
        /// <summary>
        /// <para>Optional end line of breakpoint location if the location covers a range.</para>
        /// </summary>
        public long? EndLine { get; }
        /// <summary>
        /// <para>Optional end column of breakpoint location if the location covers a range.</para>
        /// </summary>
        public long? EndColumn { get; }
        public BreakpointLocation(long line, long? column = null, long? endLine = null, long? endColumn = null)
        {
            Line = line;
            Column = column;
            EndLine = endLine;
            EndColumn = endColumn;
        }
    }
}
