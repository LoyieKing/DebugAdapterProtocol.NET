using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request starts the debuggee to run again.</para>
    /// </summary>
    public class ContinueRequest : Request<ContinueRequestArguments>
    {
        public ContinueRequest(ContinueRequestArguments arguments)
            : base("continue", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘continue’ request.</para>
    /// </summary>
    public class ContinueRequestArguments
    {
        /// <summary>
        /// <para>Continue execution for the specified thread (if possible). If the backend cannot continue on a single thread but will continue on all threads, it should set the 'allThreadsContinued' attribute in the response to true.</para>
        /// </summary>
        public long ThreadId { get; }


        public ContinueRequestArguments(long threadId)
        {
            this.ThreadId = threadId;
        }
    }

    /// <summary>
    /// <para>Response to ‘continue’ request.</para>
    /// </summary>
    public class ContinueResponse : Response<ContinueResponse.ContinueResponseBody>
    {
        public class ContinueResponseBody
        {
            /// <summary>
            /// <para>If true, the 'continue' request has ignored the specified thread and continued all threads instead. If this attribute is missing a value of 'true' is assumed for backward compatibility.</para>
            /// </summary>
            public bool? AllThreadsContinued { get; }


            public ContinueResponseBody(bool? allThreadsContinued = null)
            {
                this.AllThreadsContinued = allThreadsContinued;
            }

        }

        internal ContinueResponse(long req_seq, bool success, ContinueResponseBody body, string message)
            : base(req_seq, "continue", success, body, message)
        {

        }
        public ContinueResponse(ContinueRequest request, bool success, ContinueResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}