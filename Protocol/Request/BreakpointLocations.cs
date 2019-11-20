using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The ‘breakpointLocations’ request returns all possible locations for source breakpoints in a given range.</para>
    /// </summary>
    public class BreakpointLocationsRequest : Request<BreakpointLocationsRequestArguments>
    {
        public BreakpointLocationsRequest(BreakpointLocationsRequestArguments arguments = null)
            : base("breakpointLocations", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘breakpointLocations’ request.</para>
    /// </summary>
    public class BreakpointLocationsRequestArguments
    {
        /// <summary>
        /// <para>The source location of the breakpoints; either 'source.path' or 'source.reference' must be specified.</para>
        /// </summary>
        public Source Source { get; }

        /// <summary>
        /// <para>Start line of range to search possible breakpoint locations in. If only the line is specified, the request returns all possible locations in that line.</para>
        /// </summary>
        public long Line { get; }

        /// <summary>
        /// <para>Optional start column of range to search possible breakpoint locations in. If no start column is given, the first column in the start line is assumed.</para>
        /// </summary>
        public long? Column { get; }

        /// <summary>
        /// <para>Optional end line of range to search possible breakpoint locations in. If no end line is given, then the end line is assumed to be the start line.</para>
        /// </summary>
        public long? EndLine { get; }

        /// <summary>
        /// <para>Optional end column of range to search possible breakpoint locations in. If no end column is given, then it is assumed to be in the last column of the end line.</para>
        /// </summary>
        public long? EndColumn { get; }


        public BreakpointLocationsRequestArguments(Source source, long line, long? column = null, long? endLine = null, long? endColumn = null)
        {
            this.Source = source;
            this.Line = line;
            this.Column = column;
            this.EndLine = endLine;
            this.EndColumn = endColumn;
        }
    }

    /// <summary>
    /// <para>Response to ‘breakpointLocations’ request.</para>
    /// <para>Contains possible locations for source breakpoints.</para>
    /// </summary>
    public class BreakpointLocationsResponse : Response<BreakpointLocationsResponse.BreakpointLocationsResponseBody>
    {
        public class BreakpointLocationsResponseBody
        {
            /// <summary>
            /// <para>Sorted set of possible breakpoint locations.</para>
            /// </summary>
            public BreakpointLocation[] Breakpoints { get; }


            public BreakpointLocationsResponseBody(BreakpointLocation[] breakpoints)
            {
                this.Breakpoints = breakpoints;
            }

        }

        internal BreakpointLocationsResponse(long req_seq, bool success, BreakpointLocationsResponseBody body, string message)
            : base(req_seq, "breakpointLocations", success, body, message)
        {

        }
        public BreakpointLocationsResponse(BreakpointLocationsRequest request, bool success, BreakpointLocationsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}