using DebugAdapterProtocol.Protocol.BaseProtocol;
using DebugAdapterProtocol.Protocol.Type;

namespace DebugAdapterProtocol.Protocol.Request
{

    /// <summary>
    /// <para>Modules can be retrieved from the debug adapter with the ModulesRequest which can either return all modules or a range of modules to support paging.</para>
    /// </summary>
    public class ModulesRequest : Request<ModulesRequestArguments>
    {
        public ModulesRequest(ModulesRequestArguments arguments)
            : base("modules", arguments)
        {
        }
    }

    /// <summary>
    /// <para>Arguments for ‘modules’ request.</para>
    /// </summary>
    public class ModulesRequestArguments
    {
        /// <summary>
        /// <para>The index of the first module to return; if omitted modules start at 0.</para>
        /// </summary>
        public long? StartModule { get; }

        /// <summary>
        /// <para>The number of modules to return. If moduleCount is not specified or 0, all modules are returned.</para>
        /// </summary>
        public long? ModuleCount { get; }


        public ModulesRequestArguments(long? startModule = null, long? moduleCount = null)
        {
            this.StartModule = startModule;
            this.ModuleCount = moduleCount;
        }
    }

    /// <summary>
    /// <para>Response to ‘modules’ request.</para>
    /// </summary>
    public class ModulesResponse : Response<ModulesResponse.ModulesResponseBody>
    {
        public class ModulesResponseBody
        {
            /// <summary>
            /// <para>All modules or range of modules.</para>
            /// </summary>
            public Module[] Modules { get; }

            /// <summary>
            /// <para>The total number of modules available.</para>
            /// </summary>
            public long? TotalModules { get; }


            public ModulesResponseBody(Module[] modules, long? totalModules = null)
            {
                this.Modules = modules;
                this.TotalModules = totalModules;
            }

        }

        internal ModulesResponse(long req_seq, bool success, ModulesResponseBody body, string message)
            : base(req_seq, "modules", success, body, message)
        {

        }
        public ModulesResponse(ModulesRequest request, bool success, ModulesResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }
    }

}