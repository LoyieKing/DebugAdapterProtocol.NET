using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request suspends the debuggee.</para>
    /// <para>The debug adapter first sends the response and then a ‘stopped’ event (with reason ‘pause’) after the thread has been paused successfully.</para>
    /// </summary>
    public class PauseRequest : Request<PauseRequestArguments>
    {
        public PauseRequest(PauseRequestArguments arguments)
            : base("pause", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘pause’ request.</para>
    /// </summary>
    public class PauseRequestArguments
    {
        /// <summary>
        /// <para>Pause execution for this thread.</para>
        /// </summary>
        public long ThreadId { get; }


        public PauseRequestArguments(long threadId)
        {
            this.ThreadId = threadId;
        }
    }

    /// <summary>
    /// <para>Response to ‘pause’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class PauseResponse : Response
    {
        internal PauseResponse(long req_seq, bool success, string message)
            : base(req_seq, "pause", success, message)
        {

        }
        public PauseResponse(PauseRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}