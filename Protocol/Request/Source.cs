using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request retrieves the source code for a given source reference.</para>
    /// </summary>
    public class SourceRequest : Request<SourceRequestArguments>
    {
        public SourceRequest(SourceRequestArguments arguments)
            : base("source", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘source’ request.</para>
    /// </summary>
    public class SourceRequestArguments
    {
        /// <summary>
        /// <para>Specifies the source content to load. Either source.path or source.sourceReference must be specified.</para>
        /// </summary>
        public Source Source { get; }

        /// <summary>
        /// <para>The reference to the source. This is the same as source.sourceReference. This is provided for backward compatibility since old backends do not understand the 'source' attribute.</para>
        /// </summary>
        public long SourceReference { get; }


        public SourceRequestArguments(long sourceReference, Source source = null)
        {
            this.SourceReference = sourceReference;
            this.Source = source;
        }
    }

    /// <summary>
    /// <para>Response to ‘source’ request.</para>
    /// </summary>
    public class SourceResponse : Response<SourceResponse.SourceResponseBody>
    {
        public class SourceResponseBody
        {
            /// <summary>
            /// <para>Content of the source reference.</para>
            /// </summary>
            public string Content { get; }

            /// <summary>
            /// <para>Optional content type (mime type) of the source.</para>
            /// </summary>
            public string MimeType { get; }


            public SourceResponseBody(string content, string mimeType = null)
            {
                this.Content = content;
                this.MimeType = mimeType;
            }

        }

        internal SourceResponse(long req_seq, bool success, SourceResponseBody body, string message)
            : base(req_seq, "source", success, body, message)
        {

        }
        public SourceResponse(SourceRequest request, bool success, SourceResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}