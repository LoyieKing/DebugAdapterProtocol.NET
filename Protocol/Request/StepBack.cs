using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request starts the debuggee to run one step backwards.</para>
    /// <para>The debug adapter first sends the response and then a ‘stopped’ event (with reason ‘step’) after the step has completed. Clients should only call this request if the capability ‘supportsStepBack’ is true.</para>
    /// </summary>
    public class StepBackRequest : Request<StepBackRequestArguments>
    {
        public StepBackRequest(StepBackRequestArguments arguments)
            : base("stepBack", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘stepBack’ request.</para>
    /// </summary>
    public class StepBackRequestArguments
    {
        /// <summary>
        /// <para>Execute 'stepBack' for this thread.</para>
        /// </summary>
        public long ThreadId { get; }


        public StepBackRequestArguments(long threadId)
        {
            this.ThreadId = threadId;
        }
    }

    /// <summary>
    /// <para>Response to ‘stepBack’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class StepBackResponse : Response
    {
        internal StepBackResponse(long req_seq, bool success, string message)
            : base(req_seq, "stepBack", success, message)
        {

        }
        public StepBackResponse(StepBackRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}