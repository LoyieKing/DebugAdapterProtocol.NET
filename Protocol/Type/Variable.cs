namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A Variable is a name/value pair.</para>
    /// <para>Optionally a variable can have a ‘type’ that is shown if space permits or when hovering over the variable’s name.</para>
    /// <para>An optional ‘kind’ is used to render additional properties of the variable, e.g. different icons can be used to indicate that a variable is public or private.</para>
    /// <para>If the value is structured (has children), a handle is provided to retrieve the children with the VariablesRequest.</para>
    /// <para>If the number of named or indexed children is large, the numbers should be returned via the optional ‘namedVariables’ and ‘indexedVariables’ attributes.</para>
    /// <para>The client can use this optional information to present the children in a paged UI and fetch them in chunks.</para>
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// <para>The variable's name.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// <para>The variable's value. This can be a multi-line text, e.g. for a function the body of a function.</para>
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// <para>The type of the variable's value. Typically shown in the UI when hovering over the value.</para>
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// <para>Properties of a variable that can be used to determine how to render the variable in the UI.</para>
        /// </summary>
        public VariablePresentationHint PresentationHint { get; }
        /// <summary>
        /// <para>Optional evaluatable name of this variable which can be passed to the 'EvaluateRequest' to fetch the variable's value.</para>
        /// </summary>
        public string EvaluateName { get; }
        /// <summary>
        /// <para>If variablesReference is > 0, the variable is structured and its children can be retrieved by passing variablesReference to the VariablesRequest.</para>
        /// </summary>
        public long VariablesReference { get; }
        /// <summary>
        /// <para>The number of named child variables.</para>
        /// <para>   The client can use this optional information to present the children in a paged UI and fetch them in chunks.</para>
        /// </summary>
        public long? NamedVariables { get; }
        /// <summary>
        /// <para>The number of indexed child variables.</para>
        /// <para>   The client can use this optional information to present the children in a paged UI and fetch them in chunks.</para>
        /// </summary>
        public long? IndexedVariables { get; }
        /// <summary>
        /// <para>Optional memory reference for the variable if the variable represents executable code, such as a function pointer.</para>
        /// </summary>
        public string MemoryReference { get; }
        public Variable(
            string name,
            string value,
            long variablesReference,
            string type = null,
            VariablePresentationHint presentationHint = null,
            string evaluateName = null,
            long? namedVariables = null,
            long? indexedVariables = null,
            string memoryReference = null)
        {
            Name = name;
            Value = value;
            Type = type;
            PresentationHint = presentationHint;
            EvaluateName = evaluateName;
            VariablesReference = variablesReference;
            NamedVariables = namedVariables;
            IndexedVariables = indexedVariables;
            MemoryReference = memoryReference;
        }
    }
}
