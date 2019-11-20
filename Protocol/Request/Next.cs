using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request starts the debuggee to run again for one step.</para>
    /// <para>The debug adapter first sends the response and then a ‘stopped’ event (with reason ‘step’) after the step has completed.</para>
    /// </summary>
    public class NextRequest : Request<NextRequestArguments>
    {
        public NextRequest(NextRequestArguments arguments)
            : base("next", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘next’ request.</para>
    /// </summary>
    public class NextRequestArguments
    {
        /// <summary>
        /// <para>Execute 'next' for this thread.</para>
        /// </summary>
        public long ThreadId { get; }


        public NextRequestArguments(long threadId)
        {
            this.ThreadId = threadId;
        }
    }

    /// <summary>
    /// <para>Response to ‘next’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class NextResponse : Response
    {
        internal NextResponse(long req_seq, bool success, string message)
            : base(req_seq, "next", success, message)
        {

        }
        public NextResponse(NextRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}