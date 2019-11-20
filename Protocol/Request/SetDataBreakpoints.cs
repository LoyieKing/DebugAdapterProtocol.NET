using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Replaces all existing data breakpoints with new data breakpoints.</para>
    /// <para>To clear all data breakpoints, specify an empty array.</para>
    /// <para>When a data breakpoint is hit, a ‘stopped’ event (with reason ‘data breakpoint’) is generated.</para>
    /// </summary>
    public class SetDataBreakpointsRequest : Request<SetDataBreakpointsRequestArguments>
    {
        public SetDataBreakpointsRequest(SetDataBreakpointsRequestArguments arguments)
            : base("setDataBreakpoints", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘setDataBreakpoints’ request.</para>
    /// </summary>
    public class SetDataBreakpointsRequestArguments
    {
        /// <summary>
        /// <para>The contents of this array replaces all existing data breakpoints. An empty array clears all data breakpoints.</para>
        /// </summary>
        public DataBreakpoint[] Breakpoints { get; }


        public SetDataBreakpointsRequestArguments(DataBreakpoint[] breakpoints)
        {
            this.Breakpoints = breakpoints;
        }
    }

    /// <summary>
    /// <para>Response to ‘setDataBreakpoints’ request.</para>
    /// <para>Returned is information about each breakpoint created by this request.</para>
    /// </summary>
    public class SetDataBreakpointsResponse : Response<SetDataBreakpointsResponse.SetDataBreakpointsResponseBody>
    {
        public class SetDataBreakpointsResponseBody
        {
            /// <summary>
            /// <para>Information about the data breakpoints. The array elements correspond to the elements of the input argument 'breakpoints' array.</para>
            /// </summary>
            public Breakpoint[] Breakpoints { get; }


            public SetDataBreakpointsResponseBody(Breakpoint[] breakpoints)
            {
                this.Breakpoints = breakpoints;
            }

        }

        internal SetDataBreakpointsResponse(long req_seq, bool success, SetDataBreakpointsResponseBody body, string message)
            : base(req_seq, "setDataBreakpoints", success, body, message)
        {

        }
        public SetDataBreakpointsResponse(SetDataBreakpointsRequest request, bool success, SetDataBreakpointsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}