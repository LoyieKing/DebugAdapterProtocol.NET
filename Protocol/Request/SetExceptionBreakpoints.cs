using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request configures the debuggers response to thrown exceptions. If an exception is configured to break, a ‘stopped’ event is fired (with reason ‘exception’).</para>
    /// </summary>
    public class SetExceptionBreakpointsRequest : Request<SetExceptionBreakpointsRequestArguments>
    {
        public SetExceptionBreakpointsRequest(SetExceptionBreakpointsRequestArguments arguments)
            : base("setExceptionBreakpoints", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘setExceptionBreakpoints’ request.</para>
    /// </summary>
    public class SetExceptionBreakpointsRequestArguments
    {
        /// <summary>
        /// <para>IDs of checked exception options. The set of IDs is returned via the 'exceptionBreakpointFilters' capability.</para>
        /// </summary>
        public string[] Filters { get; }

        /// <summary>
        /// <para>Configuration options for selected exceptions.</para>
        /// </summary>
        public ExceptionOptions[] ExceptionOptions { get; }


        public SetExceptionBreakpointsRequestArguments(string[] filters, ExceptionOptions[] exceptionOptions = null)
        {
            this.Filters = filters;
            this.ExceptionOptions = exceptionOptions;
        }
    }

    /// <summary>
    /// <para>Response to ‘setExceptionBreakpoints’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class SetExceptionBreakpointsResponse : Response
    {
        internal SetExceptionBreakpointsResponse(long req_seq, bool success, string message)
            : base(req_seq, "setExceptionBreakpoints", success, message)
        {

        }
        public SetExceptionBreakpointsResponse(SetExceptionBreakpointsRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}