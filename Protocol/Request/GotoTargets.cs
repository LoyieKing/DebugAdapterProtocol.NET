using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>This request retrieves the possible goto targets for the specified source location.</para>
    /// <para>These targets can be used in the ‘goto’ request.</para>
    /// <para>The GotoTargets request may only be called if the ‘supportsGotoTargetsRequest’ capability exists and is true.</para>
    /// </summary>
    public class GotoTargetsRequest : Request<GotoTargetsRequestArguments>
    {
        public GotoTargetsRequest(GotoTargetsRequestArguments arguments)
            : base("gotoTargets", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘gotoTargets’ request.</para>
    /// </summary>
    public class GotoTargetsRequestArguments
    {
        /// <summary>
        /// <para>The source location for which the goto targets are determined.</para>
        /// </summary>
        public Source Source { get; }

        /// <summary>
        /// <para>The line location for which the goto targets are determined.</para>
        /// </summary>
        public long Line { get; }

        /// <summary>
        /// <para>An optional column location for which the goto targets are determined.</para>
        /// </summary>
        public long? Column { get; }


        public GotoTargetsRequestArguments(Source source, long line, long? column = null)
        {
            this.Source = source;
            this.Line = line;
            this.Column = column;
        }
    }

    /// <summary>
    /// <para>Response to ‘gotoTargets’ request.</para>
    /// </summary>
    public class GotoTargetsResponse : Response<GotoTargetsResponse.GotoTargetsResponseBody>
    {
        public class GotoTargetsResponseBody
        {
            /// <summary>
            /// <para>The possible goto targets of the specified location.</para>
            /// </summary>
            public GotoTarget[] Targets { get; }


            public GotoTargetsResponseBody(GotoTarget[] targets)
            {
                this.Targets = targets;
            }

        }

        internal GotoTargetsResponse(long req_seq, bool success, GotoTargetsResponseBody body, string message)
            : base(req_seq, "gotoTargets", success, body, message)
        {

        }
        public GotoTargetsResponse(GotoTargetsRequest request, bool success, GotoTargetsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}