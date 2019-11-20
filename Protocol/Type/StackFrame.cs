namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A Stackframe contains the source location.</para>
    /// </summary>
    public class StackFrame
    {
        /// <summary>
        /// <para>An identifier for the stack frame. It must be unique across all threads. This id can be used to retrieve the scopes of the frame with the 'scopesRequest' or to restart the execution of a stackframe.</para>
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// <para>The name of the stack frame, typically a method name.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// <para>The optional source of the frame.</para>
        /// </summary>
        public Source Source { get; }
        /// <summary>
        /// <para>The line within the file of the frame. If source is null or doesn't exist, line is 0 and must be ignored.</para>
        /// </summary>
        public long Line { get; }
        /// <summary>
        /// <para>The column within the line. If source is null or doesn't exist, column is 0 and must be ignored.</para>
        /// </summary>
        public long Column { get; }
        /// <summary>
        /// <para>An optional end line of the range covered by the stack frame.</para>
        /// </summary>
        public long? EndLine { get; }
        /// <summary>
        /// <para>An optional end column of the range covered by the stack frame.</para>
        /// </summary>
        public long? EndColumn { get; }
        /// <summary>
        /// <para>Optional memory reference for the current instruction pointer in this frame.</para>
        /// </summary>
        public string InstructionPointerReference { get; }
        /// <summary>
        /// <para>The module associated with this frame, if any.</para>
        /// </summary>
        public /*number | string*/string ModuleId { get; }
        /// <summary>
        /// <para>An optional hint for how to present this frame in the UI. A value of 'label' can be used to indicate that the frame is an artificial frame that is used as a visual label or separator. A value of 'subtle' can be used to change the appearance of a frame in a 'subtle' way.</para>
        /// </summary>
        public StackFramePresentationHint? PresentationHint { get; }
        public StackFrame(
            long id,
            string name,
            long line,
            long column,
            Source source = null,
            long? endLine = null,
            long? endColumn = null,
            string instructionPointerReference = null,
            /*number | string*/string moduleId = null,
            StackFramePresentationHint? presentationHint = null)
        {
            Id = id;
            Name = name;
            Source = source;
            Line = line;
            Column = column;
            EndLine = endLine;
            EndColumn = endColumn;
            InstructionPointerReference = instructionPointerReference;
            ModuleId = moduleId;
            PresentationHint = presentationHint;
        }
    }
}
