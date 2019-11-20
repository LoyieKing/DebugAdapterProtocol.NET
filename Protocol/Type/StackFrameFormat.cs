namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Provides formatting information for a stack frame.</para>
    /// </summary>
    public class StackFrameFormat : ValueFormat
    {
        /// <summary>
        /// <para>Displays parameters for the stack frame.</para>
        /// </summary>
        public bool? Parameters { get; }
        /// <summary>
        /// <para>Displays the types of parameters for the stack frame.</para>
        /// </summary>
        public bool? ParameterTypes { get; }
        /// <summary>
        /// <para>Displays the names of parameters for the stack frame.</para>
        /// </summary>
        public bool? ParameterNames { get; }
        /// <summary>
        /// <para>Displays the values of parameters for the stack frame.</para>
        /// </summary>
        public bool? ParameterValues { get; }
        /// <summary>
        /// <para>Displays the line number of the stack frame.</para>
        /// </summary>
        public bool? Line { get; }
        /// <summary>
        /// <para>Displays the module of the stack frame.</para>
        /// </summary>
        public bool? Module { get; }
        /// <summary>
        /// <para>Includes all stack frames, including those the debug adapter might otherwise hide.</para>
        /// </summary>
        public bool? IncludeAll { get; }
        public StackFrameFormat(
            bool? parameters = null,
            bool? parameterTypes = null,
            bool? parameterNames = null,
            bool? parameterValues = null,
            bool? line = null,
            bool? module = null,
            bool? includeAll = null,
            bool? hex = null)
            : base(hex)
        {
            Parameters = parameters;
            ParameterTypes = parameterTypes;
            ParameterNames = parameterNames;
            ParameterValues = parameterValues;
            Line = line;
            Module = module;
            IncludeAll = includeAll;
        }
    }
}
