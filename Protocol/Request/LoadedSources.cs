using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Retrieves the set of all sources currently loaded by the debugged process.</para>
    /// </summary>
    public class LoadedSourcesRequest : Request<LoadedSourcesRequestArguments>
    {
        public LoadedSourcesRequest(LoadedSourcesRequestArguments arguments = null)
            : base("loadedSources", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘loadedSources’ request.</para>
    /// </summary>
    public class LoadedSourcesRequestArguments
    {

        public LoadedSourcesRequestArguments()
        {
        }
    }

    /// <summary>
    /// <para>Response to ‘loadedSources’ request.</para>
    /// </summary>
    public class LoadedSourcesResponse : Response<LoadedSourcesResponse.LoadedSourcesResponseBody>
    {
        public class LoadedSourcesResponseBody
        {
            /// <summary>
            /// <para>Set of loaded sources.</para>
            /// </summary>
            public Source[] Sources { get; }


            public LoadedSourcesResponseBody(Source[] sources)
            {
                this.Sources = sources;
            }

        }

        internal LoadedSourcesResponse(long req_seq, bool success, LoadedSourcesResponseBody body, string message)
            : base(req_seq, "loadedSources", success, body, message)
        {

        }
        public LoadedSourcesResponse(LoadedSourcesRequest request, bool success, LoadedSourcesResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}