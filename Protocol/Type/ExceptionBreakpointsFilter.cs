namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>An ExceptionBreakpointsFilter is shown in the UI as an option for configuring how exceptions are dealt with.</para>
    /// </summary>
    public class ExceptionBreakpointsFilter
    {
        /// <summary>
        /// <para>The internal ID of the filter. This value is passed to the setExceptionBreakpoints request.</para>
        /// </summary>
        public string Filter { get; }
        /// <summary>
        /// <para>The name of the filter. This will be shown in the UI.</para>
        /// </summary>
        public string Label { get; }
        /// <summary>
        /// <para>Initial value of the filter. If not specified a value 'false' is assumed.</para>
        /// </summary>
        public bool? Default { get; }
        public ExceptionBreakpointsFilter(string filter, string label, bool? @default = null)
        {
            Filter = filter;
            Label = label;
            Default = @default;
        }
    }
}
