using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The client of the debug protocol must send this request at the end of the sequence of configuration requests (which was started by the ‘initialized’ event).</para>
    /// </summary>
    public class ConfigurationDoneRequest : Request<ConfigurationDoneRequestArguments>
    {
        public ConfigurationDoneRequest(ConfigurationDoneRequestArguments arguments = null)
            : base("configurationDone", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘configurationDone’ request.</para>
    /// </summary>
    public class ConfigurationDoneRequestArguments
    {

        public ConfigurationDoneRequestArguments()
        {
        }
    }

    /// <summary>
    /// <para>Response to ‘configurationDone’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class ConfigurationDoneResponse : Response
    {

        internal ConfigurationDoneResponse(long req_seq, bool success, string message)
            : base(req_seq, "configurationDone", success, message)
        {

        }
        public ConfigurationDoneResponse(ConfigurationDoneRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}