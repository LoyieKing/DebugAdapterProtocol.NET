using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{
    /// <summary>
    /// <para>The ‘cancel’ request is used by the frontend to indicate that it is no longer interested in the result produced by a specific request issued earlier.</para>
    /// <para>This request has a hint characteristic: a debug adapter can only be expected to make a ‘best effort’ in honouring this request but there are no guarantees.</para>
    /// <para>The ‘cancel’ request may return an error if it could not cancel an operation but a frontend should refrain from presenting this error to end users.</para>
    /// <para>A frontend client should only call this request if the capability ‘supportsCancelRequest’ is true.</para>
    /// <para>The request that got canceled still needs to send a response back.</para>
    /// <para>This can either be a normal result (‘success’ attribute true) or an error response (‘success’ attribute false and the ‘message’ set to ‘cancelled’).</para>
    /// <para>Returning partial results from a cancelled request is possible but please note that a frontend client has no generic way for detecting that a response is partial or not.</para>
    /// </summary>
    public class CancelRequest : Request<CancelRequest.CancelArguments>
    {
        /// <summary>
        /// Arguments for ‘cancel’ request.
        /// </summary>
        public class CancelArguments
        {
            /// <summary>
            /// The ID (attribute 'seq') of the request to cancel.
            /// </summary>
            public long? RequestId { get; }

            public CancelArguments(long? requestId = null)
            {
                RequestId = requestId;
            }
        }

        public CancelRequest(CancelArguments arguments)
            : base("cancel", arguments)
        {

        }

    }

    /// <summary>
    /// Response to ‘cancel’ request. This is just an acknowledgement, so no body field is required.
    /// </summary>
    public class CancelResponse : Response
    {
        internal CancelResponse(long req_seq, bool success, string message)
            : base(req_seq, "cancel", success, message)
        {

        }
        public CancelResponse(CancelRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }


}
