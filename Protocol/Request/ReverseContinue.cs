using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request starts the debuggee to run backward. Clients should only call this request if the capability ‘supportsStepBack’ is true.</para>
    /// </summary>
    public class ReverseContinueRequest : Request<ReverseContinueRequestArguments>
    {
        public ReverseContinueRequest(ReverseContinueRequestArguments arguments)
            : base("reverseContinue", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘reverseContinue’ request.</para>
    /// </summary>
    public class ReverseContinueRequestArguments
    {
        /// <summary>
        /// <para>Execute 'reverseContinue' for this thread.</para>
        /// </summary>
        public long ThreadId { get; }


        public ReverseContinueRequestArguments(long threadId)
        {
            this.ThreadId = threadId;
        }
    }

    /// <summary>
    /// <para>Response to ‘reverseContinue’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class ReverseContinueResponse : Response
    {
        internal ReverseContinueResponse(long req_seq, bool success, string message)
            : base(req_seq, "reverseContinue", success, message)
        {

        }
        public ReverseContinueResponse(ReverseContinueRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}