using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>The request retrieves a list of all threads.</para>
    /// </summary>
    public class ThreadsRequest : BaseProtocol.Request
    {
        public ThreadsRequest()
            : base("threads")
        {
        }
    }

    /// <summary>
    /// <para>Response to ‘threads’ request.</para>
    /// </summary>
    public class ThreadsResponse : Response<ThreadsResponse.ThreadsResponseBody>
    {
        public class ThreadsResponseBody
        {
            /// <summary>
            /// <para>All threads.</para>
            /// </summary>
            public Thread[] Threads { get; }


            public ThreadsResponseBody(params Thread[] threads)
            {
                this.Threads = threads;
            }

        }

        internal ThreadsResponse(long req_seq, bool success, ThreadsResponseBody body, string message)
            : base(req_seq, "threads", success, body, message)
        {

        }
        public ThreadsResponse(ThreadsRequest request, bool success, ThreadsResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}