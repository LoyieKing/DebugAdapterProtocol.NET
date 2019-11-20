using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Evaluates the given expression in the context of the top most stack frame.</para>
    /// <para>The expression has access to any variables and arguments that are in scope.</para>
    /// </summary>
    public class EvaluateRequest : Request<EvaluateRequestArguments>
    {
        public EvaluateRequest(EvaluateRequestArguments arguments)
            : base("evaluate", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘evaluate’ request.</para>
    /// </summary>
    public class EvaluateRequestArguments
    {
        public enum ContextType
        {
            Watch,
            Repl,
            Hover
        }
        /// <summary>
        /// <para>The expression to evaluate.</para>
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// <para>Evaluate the expression in the scope of this stack frame. If not specified, the expression is evaluated in the global scope.</para>
        /// </summary>
        public long? FrameId { get; }

        /// <summary>
        /// <para>The context in which the evaluate request is run.</para>
        /// <para>Values:</para>
        /// <para>'watch': evaluate is run in a watch.</para>
        /// <para>'repl': evaluate is run from REPL console.</para>
        /// <para>'hover': evaluate is run from a data hover.</para>
        /// <para>etc.</para>
        /// </summary>
        public ContextType? Context { get; }

        /// <summary>
        /// <para>Specifies details on how to format the Evaluate result.</para>
        /// </summary>
        public ValueFormat Format { get; }


        public EvaluateRequestArguments(string expression, long? frameId = null, ContextType? context = null, ValueFormat format = null)
        {
            this.Expression = expression;
            this.FrameId = frameId;
            this.Context = context;
            this.Format = format;
        }
    }

    /// <summary>
    /// <para>Response to ‘evaluate’ request.</para>
    /// </summary>
    public class EvaluateResponse : Response<EvaluateResponse.EvaluateResponseBody>
    {
        public class EvaluateResponseBody
        {
            /// <summary>
            /// <para>The result of the evaluate request.</para>
            /// </summary>
            public string Result { get; }

            /// <summary>
            /// <para>The optional type of the evaluate result.</para>
            /// </summary>
            public string Type { get; }

            /// <summary>
            /// <para>Properties of a evaluate result that can be used to determine how to render the result in the UI.</para>
            /// </summary>
            public VariablePresentationHint PresentationHint { get; }

            /// <summary>
            /// <para>If variablesReference is > 0, the evaluate result is structured and its children can be retrieved by passing variablesReference to the VariablesRequest. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
            /// </summary>
            public long VariablesReference { get; }

            /// <summary>
            /// <para>The number of named child variables.</para>
            /// <para>The client can use this optional information to present the variables in a paged UI and fetch them in chunks. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
            /// </summary>
            public long? NamedVariables { get; }

            /// <summary>
            /// <para>The number of indexed child variables.</para>
            /// <para>The client can use this optional information to present the variables in a paged UI and fetch them in chunks. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
            /// </summary>
            public long? IndexedVariables { get; }

            /// <summary>
            /// <para>Memory reference to a location appropriate for this result. For pointer type eval results, this is generally a reference to the memory address contained in the pointer.</para>
            /// </summary>
            public string MemoryReference { get; }


            public EvaluateResponseBody(
                string result,
                long variablesReference,
                string type = null,
                VariablePresentationHint presentationHint = null,
                long? namedVariables = null,
                long? indexedVariables = null,
                string memoryReference = null)
            {
                this.Result = result;
                this.VariablesReference = variablesReference;
                this.Type = type;
                this.PresentationHint = presentationHint;
                this.NamedVariables = namedVariables;
                this.IndexedVariables = indexedVariables;
                this.MemoryReference = memoryReference;
            }

        }

        internal EvaluateResponse(long req_seq, bool success, EvaluateResponseBody body, string message)
            : base(req_seq, "evaluate", success, body, message)
        {

        }
        public EvaluateResponse(EvaluateRequest request, bool success, EvaluateResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}