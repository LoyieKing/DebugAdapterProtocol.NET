using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Retrieves the details of the exception that caused this event to be raised.</para>
    /// </summary>
    public class ExceptionInfoRequest : Request<ExceptionInfoRequestArguments>
    {
        public ExceptionInfoRequest(ExceptionInfoRequestArguments arguments)
            : base("exceptionInfo", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘exceptionInfo’ request.</para>
    /// </summary>
    public class ExceptionInfoRequestArguments
    {
        /// <summary>
        /// <para>Thread for which exception information should be retrieved.</para>
        /// </summary>
        public long ThreadId { get; }


        public ExceptionInfoRequestArguments(long threadId)
        {
            this.ThreadId = threadId;
        }
    }

    /// <summary>
    /// <para>Response to ‘exceptionInfo’ request.</para>
    /// </summary>
    public class ExceptionInfoResponse : Response<ExceptionInfoResponse.ExceptionInfoResponseBody>
    {
        public class ExceptionInfoResponseBody
        {
            /// <summary>
            /// <para>ID of the exception that was thrown.</para>
            /// </summary>
            public string ExceptionId { get; }

            /// <summary>
            /// <para>Descriptive text for the exception provided by the debug adapter.</para>
            /// </summary>
            public string Description { get; }

            /// <summary>
            /// <para>Mode that caused the exception notification to be raised.</para>
            /// </summary>
            public ExceptionBreakMode BreakMode { get; }

            /// <summary>
            /// <para>Detailed information about the exception.</para>
            /// </summary>
            public ExceptionDetails Details { get; }


            public ExceptionInfoResponseBody(string exceptionId, ExceptionBreakMode breakMode, string description = null, ExceptionDetails details = null)
            {
                this.ExceptionId = exceptionId;
                this.BreakMode = breakMode;
                this.Description = description;
                this.Details = details;
            }

        }


        internal ExceptionInfoResponse(long req_seq, bool success, ExceptionInfoResponseBody body, string message)
            : base(req_seq, "exceptionInfo", success, body, message)
        {

        }
        public ExceptionInfoResponse(ExceptionInfoRequest request, bool success, ExceptionInfoResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}