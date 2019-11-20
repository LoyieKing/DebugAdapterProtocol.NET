using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Set the variable with the given name in the variable container to a new value.</para>
    /// </summary>
    public class SetVariableRequest : Request<SetVariableRequestArguments>
    {
        public SetVariableRequest(SetVariableRequestArguments arguments)
            : base("setVariable", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘setVariable’ request.</para>
    /// </summary>
    public class SetVariableRequestArguments
    {
        /// <summary>
        /// <para>The reference of the variable container.</para>
        /// </summary>
        public long VariablesReference { get; }

        /// <summary>
        /// <para>The name of the variable in the container.</para>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// <para>The value of the variable.</para>
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// <para>Specifies details on how to format the response value.</para>
        /// </summary>
        public ValueFormat Format { get; }


        public SetVariableRequestArguments(long variablesReference, string name, string value, ValueFormat format = null)
        {
            this.VariablesReference = variablesReference;
            this.Name = name;
            this.Value = value;
            this.Format = format;
        }
    }

    /// <summary>
    /// <para>Response to ‘setVariable’ request.</para>
    /// </summary>
    public class SetVariableResponse : Response<SetVariableResponse.SetVariableResponseBody>
    {
        public class SetVariableResponseBody
        {
            /// <summary>
            /// <para>The new value of the variable.</para>
            /// </summary>
            public string Value { get; }

            /// <summary>
            /// <para>The type of the new value. Typically shown in the UI when hovering over the value.</para>
            /// </summary>
            public string Type { get; }

            /// <summary>
            /// <para>If variablesReference is > 0, the new value is structured and its children can be retrieved by passing variablesReference to the VariablesRequest. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
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


            public SetVariableResponseBody(string value, string type = null, long? variablesReference = null, long? namedVariables = null, long? indexedVariables = null)
            {
                this.Value = value;
                this.Type = type;
                this.VariablesReference = variablesReference;
                this.NamedVariables = namedVariables;
                this.IndexedVariables = indexedVariables;
            }

        }

        internal SetVariableResponse(long req_seq, bool success, SetVariableResponseBody body, string message)
            : base(req_seq, "setVariable", success, body, message)
        {

        }
        public SetVariableResponse(SetVariableRequest request, bool success, SetVariableResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}