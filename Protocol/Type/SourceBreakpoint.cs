namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Properties of a breakpoint or logpoint passed to the setBreakpoints request.</para>
    /// </summary>
    public class SourceBreakpoint
    {
        /// <summary>
        /// <para>The source line of the breakpoint or logpoint.</para>
        /// </summary>
        public int Line { get; }
        /// <summary>
        /// <para>An optional source column of the breakpoint.</para>
        /// </summary>
        public int? Column { get; }
        /// <summary>
        /// <para>An optional expression for conditional breakpoints.</para>
        /// </summary>
        public string Condition { get; }
        /// <summary>
        /// <para>An optional expression that controls how many hits of the breakpoint are ignored. The backend is expected to interpret the expression as needed.</para>
        /// </summary>
        public string HitCondition { get; }
        /// <summary>
        /// <para>If this attribute exists and is non-empty, the backend must not 'break' (stop) but log the message instead. Expressions within {} are interpolated.</para>
        /// </summary>
        public string LogMessage { get; }
        public SourceBreakpoint(int line, int? column = null, string condition = null, string hitCondition = null, string logMessage = null)
        {
            Line = line;
            Column = column;
            Condition = condition;
            HitCondition = hitCondition;
            LogMessage = logMessage;
        }
    }
}
