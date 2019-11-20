using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The ‘initialize’ request is sent as the first request from the client to the debug adapter in order to configure it with client capabilities and to retrieve capabilities from the debug adapter.</para>
    /// <para>Until the debug adapter has responded to with an ‘initialize’ response, the client must not send any additional requests or events to the debug adapter. In addition the debug adapter is not allowed to send any requests or events to the client until it has responded with an ‘initialize’ response.</para>
    /// <para>The ‘initialize’ request may only be sent once.</para>
    /// </summary>
    public class InitializeRequest : Request<InitializeRequestArguments>
    {
        public InitializeRequest(InitializeRequestArguments arguments)
            : base("initialize", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘initialize’ request.</para>
    /// </summary>
    public class InitializeRequestArguments
    {
        /// <summary>
        /// <para>The ID of the (frontend) client using this adapter.</para>
        /// </summary>
        public string ClientID { get; }

        /// <summary>
        /// <para>The human readable name of the (frontend) client using this adapter.</para>
        /// </summary>
        public string ClientName { get; }

        /// <summary>
        /// <para>The ID of the debug adapter.</para>
        /// </summary>
        public string AdapterID { get; }

        /// <summary>
        /// <para>The ISO-639 locale of the (frontend) client using this adapter, e.g. en-US or de-CH.</para>
        /// </summary>
        public string Locale { get; }

        /// <summary>
        /// <para>If true all line numbers are 1-based (default).</para>
        /// </summary>
        public bool? LinesStartAt1 { get; }

        /// <summary>
        /// <para>If true all column numbers are 1-based (default).</para>
        /// </summary>
        public bool? ColumnsStartAt1 { get; }

        /// <summary>
        /// <para>Determines in what format paths are specified. The default is 'path', which is the native format.</para>
        /// <para>Values: 'path', 'uri', etc.</para>
        /// </summary>
        public string PathFormat { get; }

        /// <summary>
        /// <para>Client supports the optional type attribute for variables.</para>
        /// </summary>
        public bool? SupportsVariableType { get; }

        /// <summary>
        /// <para>Client supports the paging of variables.</para>
        /// </summary>
        public bool? SupportsVariablePaging { get; }

        /// <summary>
        /// <para>Client supports the runInTerminal request.</para>
        /// </summary>
        public bool? SupportsRunInTerminalRequest { get; }

        /// <summary>
        /// <para>Client supports memory references.</para>
        /// </summary>
        public bool? SupportsMemoryReferences { get; }


        public InitializeRequestArguments(
            string adapterID,
            string clientID = null,
            string clientName = null,
            string locale = null,
            bool? linesStartAt1 = null,
            bool? columnsStartAt1 = null,
            string pathFormat = null,
            bool? supportsVariableType = null,
            bool? supportsVariablePaging = null,
            bool? supportsRunInTerminalRequest = null,
            bool? supportsMemoryReferences = null)
        {
            this.AdapterID = adapterID;
            this.ClientID = clientID;
            this.ClientName = clientName;
            this.Locale = locale;
            this.LinesStartAt1 = linesStartAt1;
            this.ColumnsStartAt1 = columnsStartAt1;
            this.PathFormat = pathFormat;
            this.SupportsVariableType = supportsVariableType;
            this.SupportsVariablePaging = supportsVariablePaging;
            this.SupportsRunInTerminalRequest = supportsRunInTerminalRequest;
            this.SupportsMemoryReferences = supportsMemoryReferences;
        }
    }

    /// <summary>
    /// <para>Response to ‘initialize’ request.</para>
    /// </summary>
    public class InitializeResponse : Response<Capabilities>
    {
        internal InitializeResponse(long req_seq, bool success, Capabilities body, string message)
            : base(req_seq, "initialize", success, body, message)
        {

        }

        public InitializeResponse(InitializeRequest request, bool success, Capabilities body = null, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}