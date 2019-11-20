namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>An ExceptionPathSegment represents a segment in a path that is used to match leafs or nodes in a tree of exceptions. If a segment consists of more than one name, it matches the names provided if ‘negate’ is false or missing or it matches anything except the names provided if ‘negate’ is true.</para>
    /// </summary>
    public class ExceptionPathSegment
    {
        /// <summary>
        /// <para>If false or missing this segment matches the names provided, otherwise it matches anything except the names provided.</para>
        /// </summary>
        public bool? Negate { get; }
        /// <summary>
        /// <para>Depending on the value of 'negate' the names that should match or not match.</para>
        /// </summary>
        public string[] Names { get; }
        public ExceptionPathSegment(string[] names, bool? negate = null)
        {
            Negate = negate;
            Names = names;
        }
    }
}
