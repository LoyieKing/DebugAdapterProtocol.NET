namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>The checksum of an item calculated by the specified algorithm.</para>
    /// </summary>
    public class Checksum
    {
        /// <summary>
        /// <para>The algorithm used to calculate this checksum.</para>
        /// </summary>
        public ChecksumAlgorithm Algorithm { get; }
        /// <summary>
        /// <para>Value of the checksum.</para>
        /// </summary>
        public string checksum { get; }
        public Checksum(ChecksumAlgorithm algorithm, string checksum)
        {
            Algorithm = algorithm;
            this.checksum = checksum;
        }
    }
}
