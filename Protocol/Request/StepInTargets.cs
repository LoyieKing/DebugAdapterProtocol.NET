using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>This request retrieves the possible stepIn targets for the specified stack frame.</para>
    /// <para>These targets can be used in the ‘stepIn’ request.</para>
    /// <para>The StepInTargets may only be called if the ‘supportsStepInTargetsRequest’ capability exists and is true.</para>
    /// </summary>
    public class StepInTargetsRequest : Request<StepInTargetsRequestArguments>
    {
        public StepInTargetsRequest(StepInTargetsRequestArguments arguments)
            : base("stepInTargets", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘stepInTargets’ request.</para>
    /// </summary>
    public class StepInTargetsRequestArguments
    {
        /// <summary>
        /// <para>The stack frame for which to retrieve the possible stepIn targets.</para>
        /// </summary>
        public long FrameId { get; }


        public StepInTargetsRequestArguments(long frameId)
        {
            this.FrameId = frameId;
        }
    }

    /// <summary>
    /// <para>Response to ‘stepInTargets’ request.</para>
    /// </summary>
    public class StepInTargetsResponse : Response<StepInTargetsResponse.StepInTargetsResponseBody>
    {
        public class StepInTargetsResponseBody
        {
            /// <summary>
            /// <para>The possible stepIn targets of the specified source location.</para>
            /// </summary>
            public StepInTarget[] Targets { get; }


            public StepInTargetsResponseBody(StepInTarget[] targets)
            {
                this.Targets = targets;
            }

        }

        internal StepInTargetsResponse(long req_seq, bool success, StepInTargetsResponseBody body, string message)
            : base(req_seq, "stepInTargets", success, body, message)
        {

        }
        public StepInTargetsResponse(StepInTargetsRequest request, bool success, StepInTargetsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}