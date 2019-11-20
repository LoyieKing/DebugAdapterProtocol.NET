using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Replaces all existing function breakpoints with new function breakpoints.</para>
    /// <para>To clear all function breakpoints, specify an empty array.</para>
    /// <para>When a function breakpoint is hit, a ‘stopped’ event (with reason ‘function breakpoint’) is generated.</para>
    /// </summary>
    public class SetFunctionBreakpointsRequest : Request<SetFunctionBreakpointsRequestArguments>
    {
        public SetFunctionBreakpointsRequest(SetFunctionBreakpointsRequestArguments arguments)
            : base("setFunctionBreakpoints", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘setFunctionBreakpoints’ request.</para>
    /// </summary>
    public class SetFunctionBreakpointsRequestArguments
    {
        /// <summary>
        /// <para>The function names of the breakpoints.</para>
        /// </summary>
        public FunctionBreakpoint[] Breakpoints { get; }


        public SetFunctionBreakpointsRequestArguments(FunctionBreakpoint[] breakpoints)
        {
            this.Breakpoints = breakpoints;
        }
    }

    /// <summary>
    /// <para>Response to ‘setFunctionBreakpoints’ request.</para>
    /// <para>Returned is information about each breakpoint created by this request.</para>
    /// </summary>
    public class SetFunctionBreakpointsResponse : Response<SetFunctionBreakpointsResponse.SetFunctionBreakpointsResponseBody>
    {
        public class SetFunctionBreakpointsResponseBody
        {
            /// <summary>
            /// <para>Information about the breakpoints. The array elements correspond to the elements of the 'breakpoints' array.</para>
            /// </summary>
            public Breakpoint[] Breakpoints { get; }


            public SetFunctionBreakpointsResponseBody(Breakpoint[] breakpoints)
            {
                this.Breakpoints = breakpoints;
            }

        }

        internal SetFunctionBreakpointsResponse(long req_seq, bool success, SetFunctionBreakpointsResponseBody body, string message)
            : base(req_seq, "setFunctionBreakpoints", success, body, message)
        {

        }
        public SetFunctionBreakpointsResponse(SetFunctionBreakpointsRequest request, bool success, SetFunctionBreakpointsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}