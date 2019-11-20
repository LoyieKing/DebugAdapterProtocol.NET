namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Properties of a breakpoint passed to the setFunctionBreakpoints request.</para>
    /// </summary>
    public class FunctionBreakpoint
    {
        /// <summary>
        /// <para>The name of the function.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// <para>An optional expression for conditional breakpoints.</para>
        /// </summary>
        public string Condition { get; }
        /// <summary>
        /// <para>An optional expression that controls how many hits of the breakpoint are ignored. The backend is expected to interpret the expression as needed.</para>
        /// </summary>
        public string HitCondition { get; }
        public FunctionBreakpoint(string name, string condition = null, string hitCondition = null)
        {
            Name = name;
            Condition = condition;
            HitCondition = hitCondition;
        }
    }
}
