using DebugAdapterProtocol.Protocol.BaseProtocol;
using System.Collections.Generic;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The attach request is sent from the client to the debug adapter to attach to a debuggee that is already running. Since attaching is debugger/runtime specific, the arguments for this request are not part of this specification.</para>
    /// </summary>
    public class AttachRequest : Request<AttachRequestArguments>
    {
        public AttachRequest(AttachRequestArguments arguments)
            : base("attach", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘attach’ request. Additional attributes are implementation specific.</para>
    /// </summary>
    public class AttachRequestArguments
    {
        /// <summary>
        /// <para>Optional data from the previous, restarted session.</para>
        /// <para>The data is sent as the 'restart' attribute of the 'terminated' event.</para>
        /// <para>The client should leave the data intact.</para>
        /// </summary>
        public Dictionary<string, object> __restart { get; }


        public AttachRequestArguments(Dictionary<string, object> __restart = null)
        {
            this.__restart = __restart;
        }
    }

    /// <summary>
    /// <para>Response to ‘attach’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class AttachResponse : Response
    {
        internal AttachResponse(long req_seq, bool success, string message)
            :base(req_seq,"attach",success,message)
        {

        }
        public AttachResponse(AttachRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}