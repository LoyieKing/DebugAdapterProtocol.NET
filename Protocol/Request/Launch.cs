using DebugAdapterProtocol.Protocol.BaseProtocol;
using System.Collections.Generic;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The launch request is sent from the client to the debug adapter to start the debuggee with or without debugging (if ‘noDebug’ is true). Since launching is debugger/runtime specific, the arguments for this request are not part of this specification.</para>
    /// </summary>
    public class LaunchRequest : Request<Dictionary<string,object>>
    {
        public LaunchRequest(Dictionary<string, object> arguments)
            : base("launch", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘launch’ request. Additional attributes are implementation specific.</para>
    /// </summary>
    public class LaunchRequestArguments
    {
        /// <summary>
        /// <para>If noDebug is true the launch request should launch the program without enabling debugging.</para>
        /// </summary>
        public bool? NoDebug { get; }

        /// <summary>
        /// <para>Optional data from the previous, restarted session.</para>
        /// <para>The data is sent as the 'restart' attribute of the 'terminated' event.</para>
        /// <para>The client should leave the data intact.</para>
        /// </summary>
        public Dictionary<string, object> __restart { get; }


        public LaunchRequestArguments(bool? noDebug = null, Dictionary<string, object> __restart = null)
        {
            this.NoDebug = noDebug;
            this.__restart = __restart;
        }
    }

    /// <summary>
    /// <para>Response to ‘launch’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class LaunchResponse : Response
    {
        internal LaunchResponse(long req_seq, bool success, string message)
            : base(req_seq, "launch", success, message)
        {

        }
        public LaunchResponse(LaunchRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}