using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request sets the location where the debuggee will continue to run.</para>
    /// <para>This makes it possible to skip the execution of code or to executed code again.</para>
    /// <para>The code between the current location and the goto target is not executed but skipped.</para>
    /// <para>The debug adapter first sends the response and then a ‘stopped’ event with reason ‘goto’.</para>
    /// </summary>
    public class GotoRequest : Request<GotoRequestArguments>
    {
        public GotoRequest(GotoRequestArguments arguments)
            : base("goto", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘goto’ request.</para>
    /// </summary>
    public class GotoRequestArguments
    {
        /// <summary>
        /// <para>Set the goto target for this thread.</para>
        /// </summary>
        public long ThreadId { get; }

        /// <summary>
        /// <para>The location where the debuggee will continue to run.</para>
        /// </summary>
        public long TargetId { get; }


        public GotoRequestArguments(long threadId, long targetId)
        {
            this.ThreadId = threadId;
            this.TargetId = targetId;
        }
    }

    /// <summary>
    /// <para>Response to ‘goto’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class GotoResponse : Response
    {
        internal GotoResponse(long req_seq, bool success, string message)
            : base(req_seq, "goto", success, message)
        {

        }
        public GotoResponse(GotoRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}