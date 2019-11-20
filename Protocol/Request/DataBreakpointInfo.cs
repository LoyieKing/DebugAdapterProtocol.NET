using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Obtains information on a possible data breakpoint that could be set on an expression or variable.</para>
    /// </summary>
    public class DataBreakpointInfoRequest : Request<DataBreakpointInfoRequestArguments>
    {
        public DataBreakpointInfoRequest(DataBreakpointInfoRequestArguments arguments)
            : base("dataBreakpointInfo", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘dataBreakpointInfo’ request.</para>
    /// </summary>
    public class DataBreakpointInfoRequestArguments
    {
        /// <summary>
        /// <para>Reference to the Variable container if the data breakpoint is requested for a child of the container.</para>
        /// </summary>
        public long? VariablesReference { get; }

        /// <summary>
        /// <para>The name of the Variable's child to obtain data breakpoint information for. If variableReference isn’t provided, this can be an expression.</para>
        /// </summary>
        public string Name { get; }


        public DataBreakpointInfoRequestArguments(string name, long? variablesReference = null)
        {
            this.Name = name;
            this.VariablesReference = variablesReference;
        }
    }

    /// <summary>
    /// <para>Response to ‘dataBreakpointInfo’ request.</para>
    /// </summary>
    public class DataBreakpointInfoResponse : Response<DataBreakpointInfoResponse.DataBreakpointInfoResponseBody>
    {
        public class DataBreakpointInfoResponseBody
        {
            /// <summary>
            /// <para>An identifier for the data on which a data breakpoint can be registered with the setDataBreakpoints request or null if no data breakpoint is available.</para>
            /// </summary>
            public string DataId { get; }

            /// <summary>
            /// <para>UI string that describes on what data the breakpoint is set on or why a data breakpoint is not available.</para>
            /// </summary>
            public string Description { get; }

            /// <summary>
            /// <para>Optional attribute listing the available access types for a potential data breakpoint. A UI frontend could surface this information.</para>
            /// </summary>
            public DataBreakpointAccessType[] AccessTypes { get; }

            /// <summary>
            /// <para>Optional attribute indicating that a potential data breakpoint could be persisted across sessions.</para>
            /// </summary>
            public bool? CanPersist { get; }


            public DataBreakpointInfoResponseBody(string description, string dataId = null, DataBreakpointAccessType[] accessTypes = null, bool? canPersist = null)
            {
                this.Description = description;
                this.DataId = dataId;
                this.AccessTypes = accessTypes;
                this.CanPersist = canPersist;
            }

        }

        internal DataBreakpointInfoResponse(long req_seq, bool success, DataBreakpointInfoResponseBody body, string message)
            : base(req_seq, "dataBreakpointInfo", success, body, message)
        {

        }
        public DataBreakpointInfoResponse(DataBreakpointInfoRequest request, bool success, DataBreakpointInfoResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}