using DebugAdapterProtocol.Protocol.BaseProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebugAdapterProtocol.Protocol.ReverseRequest
{
    /// <summary>
    /// This request is sent from the debug adapter to the client to run a command in a terminal. This is typically used to launch the debuggee in a terminal provided by the client.
    /// </summary>
    public class RunInTerminalRequest : Request<RunInTerminalRequestArguments>
    {
        public RunInTerminalRequest(RunInTerminalRequestArguments args)
            : base("runInTerminal", args)
        {
        }
    }

    /// <summary>
    /// Arguments for ‘runInTerminal’ request.
    /// </summary>
    public class RunInTerminalRequestArguments
    {
        public enum TerminalKind
        {
            Integrated,
            External
        }

        /// <summary>
        /// What kind of terminal to launch.
        /// </summary>
        public TerminalKind? Kind { get; set; }

        /// <summary>
        /// Optional title of the terminal.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Working directory of the command.
        /// </summary>
        public string Cwd { get; set; }

        /// <summary>
        /// List of arguments. The first argument is the command to run.
        /// </summary>
        public string[] Args { get; set; }

        /// <summary>
        /// Environment key-value pairs that are added to or removed from the default environment.
        /// </summary>
        public Dictionary<string, string> Env { get; set; }

        public RunInTerminalRequestArguments(string cwd, string[] args, TerminalKind? kind = null, string title = null, Dictionary<string, string> env = null)
        {
            Cwd = cwd;
            Args = args;
            Kind = kind;
            Title = title;
            Env = env;
        }
    }

    /// <summary>
    /// Response to ‘runInTerminal’ request.
    /// </summary>
    public class RunInTerminalResponse : Response<RunInTerminalResponse.RunInTerminalResponseBody>
    {
        public class RunInTerminalResponseBody
        {
            /// <summary>
            /// The process ID. The value should be less than or equal to 2147483647 (2^31 - 1).
            /// </summary>
            public int ProcessId { get; }

            /// <summary>
            /// The process ID of the terminal shell. The value should be less than or equal to 2147483647 (2^31 - 1).
            /// </summary>
            public int ShellProcessId { get; }
        }

        public RunInTerminalResponse(RunInTerminalRequest request, bool success, RunInTerminalResponseBody body, string message = null)
            : base(request, success, body, message)
        {
        }

    }
}
