namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Properties of a data breakpoint passed to the setDataBreakpoints request.</para>
    /// </summary>
    public class DataBreakpoint
    {
        /// <summary>
        /// <para>An id representing the data. This id is returned from the dataBreakpointInfo request.</para>
        /// </summary>
        public string DataId { get; }
        /// <summary>
        /// <para>The access type of the data.</para>
        /// </summary>
        public DataBreakpointAccessType? AccessType { get; }
        /// <summary>
        /// <para>An optional expression for conditional breakpoints.</para>
        /// </summary>
        public string Condition { get; }
        /// <summary>
        /// <para>An optional expression that controls how many hits of the breakpoint are ignored. The backend is expected to interpret the expression as needed.</para>
        /// </summary>
        public string HitCondition { get; }
        public DataBreakpoint(string dataId, DataBreakpointAccessType? accessType = null, string condition = null, string hitCondition = null)
        {
            DataId = dataId;
            AccessType = accessType;
            Condition = condition;
            HitCondition = hitCondition;
        }
    }
}
