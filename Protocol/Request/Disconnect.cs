using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The ‘disconnect’ request is sent from the client to the debug adapter in order to stop debugging. It asks the debug adapter to disconnect from the debuggee and to terminate the debug adapter. If the debuggee has been started with the ‘launch’ request, the ‘disconnect’ request terminates the debuggee. If the ‘attach’ request was used to connect to the debuggee, ‘disconnect’ does not terminate the debuggee. This behavior can be controlled with the ‘terminateDebuggee’ argument (if supported by the debug adapter).</para>
    /// </summary>
    public class DisconnectRequest : Request<DisconnectRequestArguments>
    {
        public DisconnectRequest(DisconnectRequestArguments arguments = null)
            : base("disconnect", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘disconnect’ request.</para>
    /// </summary>
    public class DisconnectRequestArguments
    {
        /// <summary>
        /// <para>A value of true indicates that this 'disconnect' request is part of a restart sequence.</para>
        /// </summary>
        public bool? Restart { get; }

        /// <summary>
        /// <para>Indicates whether the debuggee should be terminated when the debugger is disconnected.</para>
        /// <para>If unspecified, the debug adapter is free to do whatever it thinks is best.</para>
        /// <para>A client can only rely on this attribute being properly honored if a debug adapter returns true for the 'supportTerminateDebuggee' capability.</para>
        /// </summary>
        public bool? TerminateDebuggee { get; }


        public DisconnectRequestArguments(bool? restart = null, bool? terminateDebuggee = null)
        {
            this.Restart = restart;
            this.TerminateDebuggee = terminateDebuggee;
        }
    }

    /// <summary>
    /// <para>Response to ‘disconnect’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class DisconnectResponse : Response
    {
        internal DisconnectResponse(long req_seq, bool success, string message)
            : base(req_seq, "disconnect", success, message)
        {

        }
        public DisconnectResponse(DisconnectRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}