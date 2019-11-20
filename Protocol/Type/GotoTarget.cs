namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A GotoTarget describes a code location that can be used as a target in the ‘goto’ request.</para>
    /// <para>The possible goto targets can be determined via the ‘gotoTargets’ request.</para>
    /// </summary>
    public class GotoTarget
    {
        /// <summary>
        /// <para>Unique identifier for a goto target. This is used in the goto request.</para>
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// <para>The name of the goto target (shown in the UI).</para>
        /// </summary>
        public string Label { get; }
        /// <summary>
        /// <para>The line of the goto target.</para>
        /// </summary>
        public long Line { get; }
        /// <summary>
        /// <para>An optional column of the goto target.</para>
        /// </summary>
        public long? Column { get; }
        /// <summary>
        /// <para>An optional end line of the range covered by the goto target.</para>
        /// </summary>
        public long? EndLine { get; }
        /// <summary>
        /// <para>An optional end column of the range covered by the goto target.</para>
        /// </summary>
        public long? EndColumn { get; }
        /// <summary>
        /// <para>Optional memory reference for the instruction pointer value represented by this target.</para>
        /// </summary>
        public string InstructionPointerReference { get; }
        public GotoTarget(
            long id,
            string label,
            long line,
            long? column = null,
            long? endLine = null,
            long? endColumn = null,
            string instructionPointerReference = null)
        {
            Id = id;
            Label = label;
            Line = line;
            Column = column;
            EndLine = endLine;
            EndColumn = endColumn;
            InstructionPointerReference = instructionPointerReference;
        }
    }
}
