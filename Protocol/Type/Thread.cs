namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A Thread</para>
    /// </summary>
    public class Thread
    {
        /// <summary>
        /// <para>Unique identifier for the thread.</para>
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// <para>A name of the thread.</para>
        /// </summary>
        public string Name { get; }
        public Thread(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
