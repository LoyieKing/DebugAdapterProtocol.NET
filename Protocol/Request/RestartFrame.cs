using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request restarts execution of the specified stackframe.</para>
    /// <para>The debug adapter first sends the response and then a ‘stopped’ event (with reason ‘restart’) after the restart has completed.</para>
    /// </summary>
    public class RestartFrameRequest : Request<RestartFrameRequestArguments>
    {
        public RestartFrameRequest(RestartFrameRequestArguments arguments)
            : base("restartFrame", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘restartFrame’ request.</para>
    /// </summary>
    public class RestartFrameRequestArguments
    {
        /// <summary>
        /// <para>Restart this stackframe.</para>
        /// </summary>
        public long FrameId { get; }


        public RestartFrameRequestArguments(long frameId)
        {
            this.FrameId = frameId;
        }
    }

    /// <summary>
    /// <para>Response to ‘restartFrame’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class RestartFrameResponse : Response
    {
        internal RestartFrameResponse(long req_seq, bool success, string message)
            : base(req_seq, "restartFrame", success, message)
        {

        }
        public RestartFrameResponse(RestartFrameRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}