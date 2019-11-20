namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Detailed information about an exception that has occurred.</para>
    /// </summary>
    public class ExceptionDetails
    {
        /// <summary>
        /// <para>Message contained in the exception.</para>
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// <para>Short type name of the exception object.</para>
        /// </summary>
        public string TypeName { get; }
        /// <summary>
        /// <para>Fully-qualified type name of the exception object.</para>
        /// </summary>
        public string FullTypeName { get; }
        /// <summary>
        /// <para>Optional expression that can be evaluated in the current scope to obtain the exception object.</para>
        /// </summary>
        public string EvaluateName { get; }
        /// <summary>
        /// <para>Stack trace at the time the exception was thrown.</para>
        /// </summary>
        public string StackTrace { get; }
        /// <summary>
        /// <para>Details of the exception contained by this exception, if any.</para>
        /// </summary>
        public ExceptionDetails[] InnerException { get; }
        public ExceptionDetails(
        string message = null,
        string typeName = null,
        string fullTypeName = null,
        string evaluateName = null,
        string stackTrace = null,
        ExceptionDetails[] innerException = null
        )
        {
            Message = message;
            TypeName = typeName;
            FullTypeName = fullTypeName;
            EvaluateName = evaluateName;
            StackTrace = stackTrace;
            InnerException = innerException;
        }
    }
}
