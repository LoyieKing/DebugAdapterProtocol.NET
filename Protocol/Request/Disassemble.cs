using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Disassembles code stored at the provided location.</para>
    /// </summary>
    public class DisassembleRequest : Request<DisassembleRequestArguments>
    {
        public DisassembleRequest(DisassembleRequestArguments arguments)
            : base("disassemble", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘disassemble’ request.</para>
    /// </summary>
    public class DisassembleRequestArguments
    {
        /// <summary>
        /// <para>Memory reference to the base location containing the instructions to disassemble.</para>
        /// </summary>
        public string MemoryReference { get; }

        /// <summary>
        /// <para>Optional offset (in bytes) to be applied to the reference location before disassembling. Can be negative.</para>
        /// </summary>
        public long? Offset { get; }

        /// <summary>
        /// <para>Optional offset (in instructions) to be applied after the byte offset (if any) before disassembling. Can be negative.</para>
        /// </summary>
        public long? InstructionOffset { get; }

        /// <summary>
        /// <para>Number of instructions to disassemble starting at the specified location and offset. An adapter must return exactly this number of instructions - any unavailable instructions should be replaced with an implementation-defined 'invalid instruction' value.</para>
        /// </summary>
        public long InstructionCount { get; }

        /// <summary>
        /// <para>If true, the adapter should attempt to resolve memory addresses and other values to symbolic names.</para>
        /// </summary>
        public bool? ResolveSymbols { get; }


        public DisassembleRequestArguments(string memoryReference, long instructionCount, long? offset = null, long? instructionOffset = null, bool? resolveSymbols = null)
        {
            this.MemoryReference = memoryReference;
            this.InstructionCount = instructionCount;
            this.Offset = offset;
            this.InstructionOffset = instructionOffset;
            this.ResolveSymbols = resolveSymbols;
        }
    }

    /// <summary>
    /// <para>Response to ‘disassemble’ request.</para>
    /// </summary>
    public class DisassembleResponse : Response<DisassembleResponse.DisassembleResponseBody>
    {
        public class DisassembleResponseBody
        {
            /// <summary>
            /// <para>The list of disassembled instructions.</para>
            /// </summary>
            public DisassembledInstruction[] Instructions { get; }


            public DisassembleResponseBody(DisassembledInstruction[] instructions)
            {
                this.Instructions = instructions;
            }

        }

        internal DisassembleResponse(long req_seq, bool success, DisassembleResponseBody body, string message)
            : base(req_seq, "disassemble", success, body, message)
        {

        }
        public DisassembleResponse(DisassembleRequest request, bool success, DisassembleResponseBody body = null, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}