namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A Scope is a named container for variables. Optionally a scope can map to a source or a range within a source.</para>
    /// </summary>
    public class Scope
    {
        /// <summary>
        /// <para>Name of the scope such as 'Arguments', 'Locals', or 'Registers'. This string is shown in the UI as is and can be translated.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// <para>An optional hint for how to present this scope in the UI. If this attribute is missing, the scope is shown with a generic UI.</para>
        /// <para>   Values: </para>
        /// <para>   'arguments': Scope contains method arguments.</para>
        /// <para>   'locals': Scope contains local variables.</para>
        /// <para>   'registers': Scope contains registers. Only a single 'registers' scope should be returned from a 'scopes' request.</para>
        /// <para>   etc.</para>
        /// </summary>
        public ScopePresentationHint? PresentationHint { get; }
        /// <summary>
        /// <para>The variables of this scope can be retrieved by passing the value of variablesReference to the VariablesRequest.</para>
        /// </summary>
        public long VariablesReference { get; }
        /// <summary>
        /// <para>The number of named variables in this scope.</para>
        /// <para>   The client can use this optional information to present the variables in a paged UI and fetch them in chunks.</para>
        /// </summary>
        public long? NamedVariables { get; }
        /// <summary>
        /// <para>The number of indexed variables in this scope.</para>
        /// <para>   The client can use this optional information to present the variables in a paged UI and fetch them in chunks.</para>
        /// </summary>
        public long? IndexedVariables { get; }
        /// <summary>
        /// <para>If true, the number of variables in this scope is large or expensive to retrieve.</para>
        /// </summary>
        public bool Expensive { get; }
        /// <summary>
        /// <para>Optional source for this scope.</para>
        /// </summary>
        public Source Source { get; }
        /// <summary>
        /// <para>Optional start line of the range covered by this scope.</para>
        /// </summary>
        public long? Line { get; }
        /// <summary>
        /// <para>Optional start column of the range covered by this scope.</para>
        /// </summary>
        public long? Column { get; }
        /// <summary>
        /// <para>Optional end line of the range covered by this scope.</para>
        /// </summary>
        public long? EndLine { get; }
        /// <summary>
        /// <para>Optional end column of the range covered by this scope.</para>
        /// </summary>
        public long? EndColumn { get; }
        public Scope(
            string name,
            long variablesReference,
            bool expensive,
            ScopePresentationHint? presentationHint = null,
            long? namedVariables = null,
            long? indexedVariables = null,
            Source source = null,
            long? line = null,
            long? column = null,
            long? endLine = null,
            long? endColumn = null)
        {
            Name = name;
            PresentationHint = presentationHint;
            VariablesReference = variablesReference;
            NamedVariables = namedVariables;
            IndexedVariables = indexedVariables;
            Expensive = expensive;
            Source = source;
            Line = line;
            Column = column;
            EndLine = endLine;
            EndColumn = endColumn;
        }
    }
}
