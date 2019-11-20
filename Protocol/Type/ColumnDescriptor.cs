namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A ColumnDescriptor specifies what module attribute to show in a column of the ModulesView, how to format it, and what the column’s label should be.</para>
    /// <para>It is only used if the underlying UI actually supports this level of customization.</para>
    /// </summary>
    public class ColumnDescriptor
    {
        public enum DataType
        {
            String,
            Number,
            Boolean,
            UnixTimestampUTC
        }
        /// <summary>
        /// <para>Name of the attribute rendered in this column.</para>
        /// </summary>
        public string AttributeName { get; }
        /// <summary>
        /// <para>Header UI label of column.</para>
        /// </summary>
        public string Label { get; }
        /// <summary>
        /// <para>Format to use for the rendered values in this column. TBD how the format strings looks like.</para>
        /// </summary>
        public string Format { get; }
        /// <summary>
        /// <para>Datatype of values in this column.  Defaults to 'string' if not specified.</para>
        /// </summary>
        public DataType? Type { get; }
        /// <summary>
        /// <para>Width of this column in characters (hint only).</para>
        /// </summary>
        public long? Width { get; }
        public ColumnDescriptor(string attributeName, string label, string format = null, DataType? type = null, long? width = null)
        {
            AttributeName = attributeName;
            Label = label;
            Format = format;
            Type = type;
            Width = width;
        }
    }
}
