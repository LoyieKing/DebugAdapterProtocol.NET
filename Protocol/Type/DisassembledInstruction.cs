namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Represents a single disassembled instruction.</para>
    /// </summary>
    public class DisassembledInstruction
    {
        /// <summary>
        /// <para>The address of the instruction. Treated as a hex value if prefixed with '0x', or as a decimal value otherwise.</para>
        /// </summary>
        public string Address { get; }
        /// <summary>
        /// <para>Optional raw bytes representing the instruction and its operands, in an implementation-defined format.</para>
        /// </summary>
        public string InstructionBytes { get; }
        /// <summary>
        /// <para>Text representing the instruction and its operands, in an implementation-defined format.</para>
        /// </summary>
        public string Instruction { get; }
        /// <summary>
        /// <para>Name of the symbol that corresponds with the location of this instruction, if any.</para>
        /// </summary>
        public string Symbol { get; }
        /// <summary>
        /// <para>Source location that corresponds to this instruction, if any. Should always be set (if available) on the first instruction returned, but can be omitted afterwards if this instruction maps to the same source file as the previous instruction.</para>
        /// </summary>
        public Source Location { get; }
        /// <summary>
        /// <para>The line within the source location that corresponds to this instruction, if any.</para>
        /// </summary>
        public long? Line { get; }
        /// <summary>
        /// <para>The column within the line that corresponds to this instruction, if any.</para>
        /// </summary>
        public long? Column { get; }
        /// <summary>
        /// <para>The end line of the range that corresponds to this instruction, if any.</para>
        /// </summary>
        public long? EndLine { get; }
        /// <summary>
        /// <para>The end column of the range that corresponds to this instruction, if any.</para>
        /// </summary>
        public long? EndColumn { get; }
        public DisassembledInstruction(
        string address,
        string instruction,
        string instructionBytes = null,
        string symbol = null,
        Source location = null,
        long? line = null,
        long? column = null,
        long? endLine = null,
        long? endColumn = null
        )
        {
            Address = address;
            InstructionBytes = instructionBytes;
            Instruction = instruction;
            Symbol = symbol;
            Location = location;
            Line = line;
            Column = column;
            EndLine = endLine;
            EndColumn = endColumn;
        }
    }
}
