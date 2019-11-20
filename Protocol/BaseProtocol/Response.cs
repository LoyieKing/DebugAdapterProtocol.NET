using Newtonsoft.Json;

namespace DebugAdapterProtocol.Protocol.BaseProtocol
{
    /// <summary>
    /// Response for a request.
    /// </summary>
    public class Response : ProtocolMessage
    {
        /// <summary>
        /// Sequence number of the corresponding request.
        /// </summary>
        [JsonProperty("request_seq")]
        public long RequestSequence { get; }

        /// <summary>
        /// Outcome of the request.
        /// <para>If true, the request was successful and the 'body' attribute may contain the result of the request.</para>
        /// <para>If the value is false, the attribute 'message' contains the error in short form and the 'body' may contain additional information (see <see cref="ErrorResponse.ErroBody.Error"/>).</para>
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// The command requested.
        /// </summary>
        public string Command { get; }

        /// <summary>
        /// Contains the raw error in short form if 'success' is false.
        /// <para>This raw error might be interpreted by the frontend and is not shown in the UI.</para>
        /// <para>Some predefined values exist.</para>
        /// <para>Values: </para>
        /// <para>'cancelled': request was cancelled.</para>
        /// <para>etc.</para>
        /// </summary>
        public string Message { get; }

        [JsonIgnore]
        public virtual bool HasBody => false;

        internal Response(long seq, string command, bool success, string message = null)
            : base("response")
        {
            RequestSequence = seq;
            Command = command;
            Success = success;
            Message = message;
        }

        public Response(Request request, bool success, string message = null)
            : base("response")
        {
            RequestSequence = request.Sequence;
            Command = request.Command;
            Success = success;
            Message = message;
        }
    }

    /// <summary>
    /// Response for a request.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        public T Body { get; }

        [JsonIgnore]
        public override bool HasBody => true;

        internal Response(long seq, string command, bool success, T body, string message = null)
            : base(seq, command, success, message)
        {
            Body = body;
        }

        public Response(Request request, bool success, T body, string message = null)
            : base(request, success, message)
        {
            Body = body;
        }
    }
}
