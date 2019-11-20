namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>The ModulesViewDescriptor is the container for all declarative configuration options of a ModuleView.</para>
    /// <para>For now it only specifies the columns to be shown in the modules view.</para>
    /// </summary>
    public class ModulesViewDescriptor
    {
        public ColumnDescriptor[] Columns { get; }
        public ModulesViewDescriptor(ColumnDescriptor[] columns)
        {
            Columns = columns;
        }
    }
}
