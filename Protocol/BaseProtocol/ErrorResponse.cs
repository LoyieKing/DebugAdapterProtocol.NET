using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.BaseProtocol
{
    /// <summary>
    /// On error (whenever ‘success’ is false), the body can provide more details.
    /// </summary>
    public class ErrorResponse : Response<ErrorResponse.ErroBody>
    {
        public class ErroBody
        {
            /// <summary>
            /// An optional, structured error message.
            /// </summary>
            public Message Error { get; }

            internal ErroBody(Message error = null)
            {
                Error = error;
            }
        }


        public ErrorResponse(Request request, ErroBody body, string message = null)
            : base(request, false, body, message)
        {
        }


    }
}
