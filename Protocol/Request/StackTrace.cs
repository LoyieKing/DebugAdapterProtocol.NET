using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;
using StackFrame = DebugAdapterProtocol.Protocol.Type.StackFrame;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request returns a stacktrace from the current execution state.</para>
    /// </summary>
    public class StackTraceRequest : Request<StackTraceRequestArguments>
    {
        public StackTraceRequest(StackTraceRequestArguments arguments)
            : base("stackTrace", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘stackTrace’ request.</para>
    /// </summary>
    public class StackTraceRequestArguments
    {
        /// <summary>
        /// <para>Retrieve the stacktrace for this thread.</para>
        /// </summary>
        public long ThreadId { get; }

        /// <summary>
        /// <para>The index of the first frame to return; if omitted frames start at 0.</para>
        /// </summary>
        public long? StartFrame { get; }

        /// <summary>
        /// <para>The maximum number of frames to return. If levels is not specified or 0, all frames are returned.</para>
        /// </summary>
        public long? Levels { get; }

        /// <summary>
        /// <para>Specifies details on how to format the stack frames.</para>
        /// </summary>
        public StackFrameFormat Format { get; }


        public StackTraceRequestArguments(long threadId, long? startFrame = null, long? levels = null, StackFrameFormat format = null)
        {
            this.ThreadId = threadId;
            this.StartFrame = startFrame;
            this.Levels = levels;
            this.Format = format;
        }
    }

    /// <summary>
    /// <para>Response to ‘stackTrace’ request.</para>
    /// </summary>
    public class StackTraceResponse : Response<StackTraceResponse.StackTraceResponseBody>
    {
        public class StackTraceResponseBody
        {
            /// <summary>
            /// <para>The frames of the stackframe. If the array has length zero, there are no stackframes available.</para>
            /// <para>This means that there is no location information available.</para>
            /// </summary>
            public StackFrame[] StackFrames { get; }

            /// <summary>
            /// <para>The total number of frames available.</para>
            /// </summary>
            public long? TotalFrames { get; }


            public StackTraceResponseBody(StackFrame[] stackFrames, long? totalFrames = null)
            {
                this.StackFrames = stackFrames;
                this.TotalFrames = totalFrames;
            }

        }

        internal StackTraceResponse(long req_seq, bool success, StackTraceResponseBody body, string message)
            : base(req_seq, "stackTrace", success, body, message)
        {

        }
        public StackTraceResponse(StackTraceRequest request, bool success, StackTraceResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}