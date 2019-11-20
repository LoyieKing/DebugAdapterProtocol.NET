using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Reads bytes from memory at the provided location.</para>
    /// </summary>
    public class ReadMemoryRequest : Request<ReadMemoryRequestArguments>
    {
        public ReadMemoryRequest(ReadMemoryRequestArguments arguments)
            : base("readMemory", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘readMemory’ request.</para>
    /// </summary>
    public class ReadMemoryRequestArguments
    {
        /// <summary>
        /// <para>Memory reference to the base location from which data should be read.</para>
        /// </summary>
        public string MemoryReference { get; }

        /// <summary>
        /// <para>Optional offset (in bytes) to be applied to the reference location before reading data. Can be negative.</para>
        /// </summary>
        public long? Offset { get; }

        /// <summary>
        /// <para>Number of bytes to read at the specified location and offset.</para>
        /// </summary>
        public long Count { get; }


        public ReadMemoryRequestArguments(string memoryReference, long count, long? offset = null)
        {
            this.MemoryReference = memoryReference;
            this.Count = count;
            this.Offset = offset;
        }
    }

    /// <summary>
    /// <para>Response to ‘readMemory’ request.</para>
    /// </summary>
    public class ReadMemoryResponse : Response<ReadMemoryResponse.ReadMemoryResponseBody>
    {
        public class ReadMemoryResponseBody
        {
            /// <summary>
            /// <para>The address of the first byte of data returned. Treated as a hex value if prefixed with '0x', or as a decimal value otherwise.</para>
            /// </summary>
            public string Address { get; }

            /// <summary>
            /// <para>The number of unreadable bytes encountered after the last successfully read byte. This can be used to determine the number of bytes that must be skipped before a subsequent 'readMemory' request will succeed.</para>
            /// </summary>
            public long? UnreadableBytes { get; }

            /// <summary>
            /// <para>The bytes read from memory, encoded using base64.</para>
            /// </summary>
            public string Data { get; }


            public ReadMemoryResponseBody(string address, long? unreadableBytes = null, string data = null)
            {
                this.Address = address;
                this.UnreadableBytes = unreadableBytes;
                this.Data = data;
            }

        }

        internal ReadMemoryResponse(long req_seq, bool success, ReadMemoryResponseBody body, string message)
            : base(req_seq, "readMemory", success, body, message)
        {

        }
        public ReadMemoryResponse(ReadMemoryRequest request, bool success, ReadMemoryResponseBody body = null, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}