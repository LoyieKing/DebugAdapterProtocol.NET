using DebugAdapterProtocol.Protocol.BaseProtocol;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request terminates the threads with the given ids.</para>
    /// </summary>
    public class TerminateThreadsRequest : Request<TerminateThreadsRequestArguments>
    {
        public TerminateThreadsRequest(TerminateThreadsRequestArguments arguments)
            : base("terminateThreads", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘terminateThreads’ request.</para>
    /// </summary>
    public class TerminateThreadsRequestArguments
    {
        /// <summary>
        /// <para>Ids of threads to be terminated.</para>
        /// </summary>
        public long[] ThreadIds { get; }


        public TerminateThreadsRequestArguments(long[] threadIds = null)
        {
            this.ThreadIds = threadIds;
        }
    }

    /// <summary>
    /// <para>Response to ‘terminateThreads’ request. This is just an acknowledgement, so no body field is required.</para>
    /// </summary>
    public class TerminateThreadsResponse : Response
    {
        internal TerminateThreadsResponse(long req_seq, bool success, string message)
            : base(req_seq, "terminateThreads", success, message)
        {

        }
        public TerminateThreadsResponse(TerminateThreadsRequest request, bool success, string message = null)
            : base(request, success, message)
        {
        }
    }

}