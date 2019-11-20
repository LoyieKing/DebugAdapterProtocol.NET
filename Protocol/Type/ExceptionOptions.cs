namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>An ExceptionOptions assigns configuration options to a set of exceptions.</para>
    /// </summary>
    public class ExceptionOptions
    {
        /// <summary>
        /// <para>A path that selects a single or multiple exceptions in a tree. If 'path' is missing, the whole tree is selected. By convention the first segment of the path is a category that is used to group exceptions in the UI.</para>
        /// </summary>
        public ExceptionPathSegment[] Path { get; }
        /// <summary>
        /// <para>Condition when a thrown exception should result in a break.</para>
        /// </summary>
        public ExceptionBreakMode BreakMode { get; }
        public ExceptionOptions(ExceptionBreakMode breakMode, ExceptionPathSegment[] path = null)
        {
            Path = path;
            BreakMode = breakMode;
        }
    }
}
