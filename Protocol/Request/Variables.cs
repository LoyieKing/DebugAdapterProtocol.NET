using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Retrieves all child variables for the given variable reference.</para>
    /// <para>An optional filter can be used to limit the fetched children to either named or indexed children.</para>
    /// </summary>
    public class VariablesRequest : Request<VariablesRequestArguments>
    {
        public VariablesRequest(VariablesRequestArguments arguments)
            : base("variables", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘variables’ request.</para>
    /// </summary>
    public class VariablesRequestArguments
    {
        public enum VariablesFilter
        {
            Indexed,
            Named
        }

        /// <summary>
        /// <para>The Variable reference.</para>
        /// </summary>
        public long VariablesReference { get; }

        /// <summary>
        /// <para>Optional filter to limit the child variables to either named or indexed. If omitted, both types are fetched.</para>
        /// </summary>
        public VariablesFilter? Filter { get; }

        /// <summary>
        /// <para>The index of the first variable to return; if omitted children start at 0.</para>
        /// </summary>
        public long? Start { get; }

        /// <summary>
        /// <para>The number of variables to return. If count is missing or 0, all variables are returned.</para>
        /// </summary>
        public long? Count { get; }

        /// <summary>
        /// <para>Specifies details on how to format the Variable values.</para>
        /// </summary>
        public ValueFormat Format { get; }


        public VariablesRequestArguments(long variablesReference, VariablesFilter? filter = null, long? start = null, long? count = null, ValueFormat format = null)
        {
            this.VariablesReference = variablesReference;
            this.Filter = filter;
            this.Start = start;
            this.Count = count;
            this.Format = format;
        }
    }

    /// <summary>
    /// <para>Response to ‘variables’ request.</para>
    /// </summary>
    public class VariablesResponse : Response<VariablesResponse.VariablesResponseBody>
    {
        public class VariablesResponseBody
        {
            /// <summary>
            /// <para>All (or a range) of variables for the given variable reference.</para>
            /// </summary>
            public Variable[] Variables { get; }


            public VariablesResponseBody(Variable[] variables)
            {
                this.Variables = variables;
            }

        }

        internal VariablesResponse(long req_seq, bool success, VariablesResponseBody body, string message)
            : base(req_seq, "variables", success, body, message)
        {

        }
        public VariablesResponse(VariablesRequest request, bool success, VariablesResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}