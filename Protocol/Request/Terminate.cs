using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The ‘terminate’ request is sent from the client to the debug adapter in order to give the debuggee a chance for terminating itself.</para>
    /// </summary>
    public class TerminateRequest : Request<TerminateRequestArguments>
    {
        public TerminateRequest(TerminateRequestArguments arguments = null)
            : base("terminate", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘terminate’ request.</para>
    /// </summary>
    public class TerminateRequestArguments
    {
        /// <summary>
        /// <para>A value of true indicates that this 'terminate' request is part of a restart sequence.</para>
        /// </summary>
        public bool? Restart { get; }


        public TerminateRequestArguments(bool? restart = null)
        {
            this.Restart = restart;
        }
    }

    /// <summary>
    /// <para>Response to ‘terminate’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class TerminateResponse : Response
    {
        internal TerminateResponse(long req_seq, bool success, string message)
            : base(req_seq, "terminate", success, message)
        {

        }
        public TerminateResponse(TerminateRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}