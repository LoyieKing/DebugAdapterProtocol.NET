using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Returns a list of possible completions for a given caret position and text.</para>
    /// <para>The CompletionsRequest may only be called if the ‘supportsCompletionsRequest’ capability exists and is true.</para>
    /// </summary>
    public class CompletionsRequest : Request<CompletionsRequestArguments>
    {
        public CompletionsRequest(CompletionsRequestArguments arguments)
            : base("completions", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘completions’ request.</para>
    /// </summary>
    public class CompletionsRequestArguments
    {
        /// <summary>
        /// <para>Returns completions in the scope of this stack frame. If not specified, the completions are returned for the global scope.</para>
        /// </summary>
        public long? FrameId { get; }

        /// <summary>
        /// <para>One or more source lines. Typically this is the text a user has typed into the debug console before he asked for completion.</para>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// <para>The character position for which to determine the completion proposals.</para>
        /// </summary>
        public long Column { get; }

        /// <summary>
        /// <para>An optional line for which to determine the completion proposals. If missing the first line of the text is assumed.</para>
        /// </summary>
        public long? Line { get; }


        public CompletionsRequestArguments(string text, long column, long? frameId = null, long? line = null)
        {
            this.Text = text;
            this.Column = column;
            this.FrameId = frameId;
            this.Line = line;
        }
    }

    /// <summary>
    /// <para>Response to ‘completions’ request.</para>
    /// </summary>
    public class CompletionsResponse : Response<CompletionsResponse.CompletionsResponseBody>
    {
        public class CompletionsResponseBody
        {
            /// <summary>
            /// <para>The possible completions for .</para>
            /// </summary>
            public CompletionItem[] Targets { get; }


            public CompletionsResponseBody(CompletionItem[] targets)
            {
                this.Targets = targets;
            }

        }
        internal CompletionsResponse(long req_seq, bool success, CompletionsResponseBody body, string message)
            : base(req_seq, "completions", success, body, message)
        {

        }
        public CompletionsResponse(CompletionsRequest request, bool success, CompletionsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}