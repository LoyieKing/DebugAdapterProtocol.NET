using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Sets multiple breakpoints for a single source and clears all previous breakpoints in that source.</para>
    /// <para>To clear all breakpoint for a source, specify an empty array.</para>
    /// <para>When a breakpoint is hit, a ‘stopped’ event (with reason ‘breakpoint’) is generated.</para>
    /// </summary>
    public class SetBreakpointsRequest : Request<SetBreakpointsRequestArguments>
    {
        public SetBreakpointsRequest(SetBreakpointsRequestArguments arguments)
            : base("setBreakpoints", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘setBreakpoints’ request.</para>
    /// </summary>
    public class SetBreakpointsRequestArguments
    {
        /// <summary>
        /// <para>The source location of the breakpoints; either 'source.path' or 'source.reference' must be specified.</para>
        /// </summary>
        public Source Source { get; }

        /// <summary>
        /// <para>The code locations of the breakpoints.</para>
        /// </summary>
        public SourceBreakpoint[] Breakpoints { get; }

        /// <summary>
        /// <para>Deprecated: The code locations of the breakpoints.</para>
        /// </summary>
        public long[] Lines { get; }

        /// <summary>
        /// <para>A value of true indicates that the underlying source has been modified which results in new breakpoint locations.</para>
        /// </summary>
        public bool? SourceModified { get; }


        public SetBreakpointsRequestArguments(Source source, SourceBreakpoint[] breakpoints = null, long[] lines = null, bool? sourceModified = null)
        {
            this.Source = source;
            this.Breakpoints = breakpoints;
            this.Lines = lines;
            this.SourceModified = sourceModified;
        }
    }

    /// <summary>
    /// <para>Response to ‘setBreakpoints’ request.</para>
    /// <para>Returned is information about each breakpoint created by this request.</para>
    /// <para>This includes the actual code location and whether the breakpoint could be verified.</para>
    /// <para>The breakpoints returned are in the same order as the elements of the ‘breakpoints’</para>
    /// <para>(or the deprecated ‘lines’) array in the arguments.</para>
    /// </summary>
    public class SetBreakpointsResponse : Response<SetBreakpointsResponse.SetBreakpointsResponseBody>
    {
        public class SetBreakpointsResponseBody
        {
            /// <summary>
            /// <para>Information about the breakpoints. The array elements are in the same order as the elements of the 'breakpoints' (or the deprecated 'lines') array in the arguments.</para>
            /// </summary>
            public Breakpoint[] Breakpoints { get; }


            public SetBreakpointsResponseBody(params Breakpoint[] breakpoints)
            {
                this.Breakpoints = breakpoints;
            }

        }

        internal SetBreakpointsResponse(long req_seq, bool success, SetBreakpointsResponseBody body, string message)
            : base(req_seq, "setBreakpoints", success, body, message)
        {

        }
        public SetBreakpointsResponse(SetBreakpointsRequest request, bool success, SetBreakpointsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}