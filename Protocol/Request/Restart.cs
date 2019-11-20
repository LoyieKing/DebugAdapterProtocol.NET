using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Restarts a debug session. If the capability ‘supportsRestartRequest’ is missing or has the value false,</para>
    /// <para>the client will implement ‘restart’ by terminating the debug adapter first and then launching it anew.</para>
    /// <para>A debug adapter can override this default behaviour by implementing a restart request</para>
    /// <para>and setting the capability ‘supportsRestartRequest’ to true.</para>
    /// </summary>
    public class RestartRequest : Request<RestartRequestArguments>
    {
        public RestartRequest(RestartRequestArguments arguments = null)
            : base("restart", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘restart’ request.</para>
    /// </summary>
    public class RestartRequestArguments
    {

        public RestartRequestArguments()
        {
        }
    }

    /// <summary>
    /// <para>Response to ‘restart’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class RestartResponse : Response
    {
        internal RestartResponse(long req_seq, bool success, string message)
            : base(req_seq, "restart", success, message)
        {

        }
        public RestartResponse(RestartRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}