using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request returns the variable scopes for a given stackframe ID.</para>
    /// </summary>
    public class ScopesRequest : Request<ScopesRequestArguments>
    {
        public ScopesRequest(ScopesRequestArguments arguments)
            : base("scopes", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘scopes’ request.</para>
    /// </summary>
    public class ScopesRequestArguments
    {
        /// <summary>
        /// <para>Retrieve the scopes for this stackframe.</para>
        /// </summary>
        public long FrameId { get; }


        public ScopesRequestArguments(long frameId)
        {
            this.FrameId = frameId;
        }
    }

    /// <summary>
    /// <para>Response to ‘scopes’ request.</para>
    /// </summary>
    public class ScopesResponse : Response<ScopesResponse.ScopesResponseBody>
    {
        public class ScopesResponseBody
        {
            /// <summary>
            /// <para>The scopes of the stackframe. If the array has length zero, there are no scopes available.</para>
            /// </summary>
            public Scope[] Scopes { get; }


            public ScopesResponseBody(params Scope[] scopes)
            {
                this.Scopes = scopes;
            }

        }

        internal ScopesResponse(long req_seq, bool success, ScopesResponseBody body, string message)
            : base(req_seq, "scopes", success, body, message)
        {

        }
        public ScopesResponse(ScopesRequest request, bool success, ScopesResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}