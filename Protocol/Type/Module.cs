namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A Module object represents a row in the modules view.</para>
    /// <para>Two attributes are mandatory: an id identifies a module in the modules view and is used in a ModuleEvent for identifying a module for adding, updating or deleting.</para>
    /// <para>The name is used to minimally render the module in the UI.</para>
    /// <para>Additional attributes can be added to the module. They will show up in the module View if they have a corresponding ColumnDescriptor.</para>
    /// <para>To avoid an unnecessary proliferation of additional attributes with similar semantics but different names</para>
    /// <para>we recommend to re-use attributes from the ‘recommended’ list below first, and only introduce new attributes if nothing appropriate could be found.</para>
    /// </summary>
    public class Module
    {
        /// <summary>
        /// <para>Unique identifier for the module.</para>
        /// </summary>
        public /*number | string*/string Id { get; }
        /// <summary>
        /// <para>A name of the module.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// <para>optional but recommended attributes.</para>
        /// <para>always try to use these first before introducing additional attributes.</para>
        /// <para>Logical full path to the module. The exact definition is implementation defined, but usually this would be a full path to the on-disk file for the module.</para>
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// <para>True if the module is optimized.</para>
        /// </summary>
        public bool? IsOptimized { get; }
        /// <summary>
        /// <para>True if the module is considered 'user code' by a debugger that supports 'Just My Code'.</para>
        /// </summary>
        public bool? IsUserCode { get; }
        /// <summary>
        /// <para>Version of Module.</para>
        /// </summary>
        public string Version { get; }
        /// <summary>
        /// <para>User understandable description of if symbols were found for the module (ex: 'Symbols Loaded', 'Symbols not found', etc.</para>
        /// </summary>
        public string SymbolStatus { get; }
        /// <summary>
        /// <para>Logical full path to the symbol file. The exact definition is implementation defined.</para>
        /// </summary>
        public string SymbolFilePath { get; }
        /// <summary>
        /// <para>Module created or modified.</para>
        /// </summary>
        public string DateTimeStamp { get; }
        /// <summary>
        /// <para>Address range covered by this module.</para>
        /// </summary>
        public string AddressRange { get; }
        public Module(
            /*number | string*/string id,
            string name,
            string path = null,
            bool? isOptimized = null,
            bool? isUserCode = null,
            string version = null,
            string symbolStatus = null,
            string symbolFilePath = null,
            string dateTimeStamp = null,
            string addressRange = null)
        {
            Id = id;
            Name = name;
            Path = path;
            IsOptimized = isOptimized;
            IsUserCode = isUserCode;
            Version = version;
            SymbolStatus = symbolStatus;
            SymbolFilePath = symbolFilePath;
            DateTimeStamp = dateTimeStamp;
            AddressRange = addressRange;
        }
    }
}
