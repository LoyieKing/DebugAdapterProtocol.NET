using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Evaluates the given ‘value’ expression and assigns it to the ‘expression’ which must be a modifiable l-value.</para>
    /// <para>The expressions have access to any variables and arguments that are in scope of the specified frame.</para>
    /// </summary>
    public class SetExpressionRequest : Request<SetExpressionRequestArguments>
    {
        public SetExpressionRequest(SetExpressionRequestArguments arguments)
            : base("setExpression", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘setExpression’ request.</para>
    /// </summary>
    public class SetExpressionRequestArguments
    {
        /// <summary>
        /// <para>The l-value expression to assign to.</para>
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// <para>The value expression to assign to the l-value expression.</para>
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// <para>Evaluate the expressions in the scope of this stack frame. If not specified, the expressions are evaluated in the global scope.</para>
        /// </summary>
        public long? FrameId { get; }

        /// <summary>
        /// <para>Specifies how the resulting value should be formatted.</para>
        /// </summary>
        public ValueFormat Format { get; }


        public SetExpressionRequestArguments(string expression, string value, long? frameId = null, ValueFormat format = null)
        {
            this.Expression = expression;
            this.Value = value;
            this.FrameId = frameId;
            this.Format = format;
        }
    }

    /// <summary>
    /// <para>Response to ‘setExpression’ request.</para>
    /// </summary>
    public class SetExpressionResponse : Response<SetExpressionResponse.SetExpressionResponseBody>
    {
        public class SetExpressionResponseBody
        {
            /// <summary>
            /// <para>The new value of the expression.</para>
            /// </summary>
            public string Value { get; }

            /// <summary>
            /// <para>The optional type of the value.</para>
            /// </summary>
            public string Type { get; }

            /// <summary>
            /// <para>Properties of a value that can be used to determine how to render the result in the UI.</para>
            /// </summary>
            public VariablePresentationHint PresentationHint { get; }

            /// <summary>
            /// <para>If variablesReference is > 0, the value is structured and its children can be retrieved by passing variablesReference to the VariablesRequest. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
            /// </summary>
            public long? VariablesReference { get; }

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


            public SetExpressionResponseBody(
                string value,
                string type = null,
                VariablePresentationHint presentationHint = null,
                long? variablesReference = null,
                long? namedVariables = null,
                long? indexedVariables = null)
            {
                this.Value = value;
                this.Type = type;
                this.PresentationHint = presentationHint;
                this.VariablesReference = variablesReference;
                this.NamedVariables = namedVariables;
                this.IndexedVariables = indexedVariables;
            }

        }

        internal SetExpressionResponse(long req_seq, bool success, SetExpressionResponseBody body, string message)
            : base(req_seq, "setExpression", success, body, message)
        {

        }
        public SetExpressionResponse(SetExpressionRequest request, bool success, SetExpressionResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}