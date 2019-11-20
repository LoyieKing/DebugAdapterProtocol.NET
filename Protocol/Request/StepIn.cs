using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request starts the debuggee to step into a function/method if possible.</para>
    /// <para>If it cannot step into a target, ‘stepIn’ behaves like ‘next’.</para>
    /// <para>The debug adapter first sends the response and then a ‘stopped’ event (with reason ‘step’) after the step has completed.</para>
    /// <para>If there are multiple function/method calls (or other targets) on the source line,</para>
    /// <para>the optional argument ‘targetId’ can be used to control into which target the ‘stepIn’ should occur.</para>
    /// <para>The list of possible targets for a given source line can be retrieved via the ‘stepInTargets’ request.</para>
    /// </summary>
    public class StepInRequest : Request<StepInRequestArguments>
    {
        public StepInRequest(StepInRequestArguments arguments)
            : base("stepIn", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘stepIn’ request.</para>
    /// </summary>
    public class StepInRequestArguments
    {
        /// <summary>
        /// <para>Execute 'stepIn' for this thread.</para>
        /// </summary>
        public long ThreadId { get; }

        /// <summary>
        /// <para>Optional id of the target to step into.</para>
        /// </summary>
        public long? TargetId { get; }


        public StepInRequestArguments(long threadId, long? targetId = null)
        {
            this.ThreadId = threadId;
            this.TargetId = targetId;
        }
    }

    /// <summary>
    /// <para>Response to ‘stepIn’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class StepInResponse : Response
    {
        internal StepInResponse(long req_seq, bool success, string message)
            : base(req_seq, "stepIn", success, message)
        {

        }
        public StepInResponse(StepInRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}