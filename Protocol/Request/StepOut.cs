using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request starts the debuggee to run again for one step.</para>
    /// <para>The debug adapter first sends the response and then a ‘stopped’ event (with reason ‘step’) after the step has completed.</para>
    /// </summary>
    public class StepOutRequest : Request<StepOutRequestArguments>
    {
        public StepOutRequest(StepOutRequestArguments arguments)
            : base("stepOut", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘stepOut’ request.</para>
    /// </summary>
    public class StepOutRequestArguments
    {
        /// <summary>
        /// <para>Execute 'stepOut' for this thread.</para>
        /// </summary>
        public long ThreadId { get; }


        public StepOutRequestArguments(long threadId)
        {
            this.ThreadId = threadId;
        }
    }

    /// <summary>
    /// <para>Response to ‘stepOut’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class StepOutResponse : Response
    {
        internal StepOutResponse(long req_seq, bool success, string message)
            : base(req_seq, "stepOut", success, message)
        {

        }
        public StepOutResponse(StepOutRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}