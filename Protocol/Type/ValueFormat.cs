namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Provides formatting information for a value.</para>
    /// </summary>
    public class ValueFormat
    {
        /// <summary>
        /// <para>Display the value in hex.</para>
        /// </summary>
        public bool? Hex { get; }
        public ValueFormat(bool? hex = null)
        {
            Hex = hex;
        }
    }
}
