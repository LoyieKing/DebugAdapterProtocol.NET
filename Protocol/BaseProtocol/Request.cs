using Newtonsoft.Json;

namespace DebugAdapterProtocol.Protocol.BaseProtocol
{
    /// <summary>
    /// A client or debug adapter initiated request.
    /// </summary>
    public class Request : ProtocolMessage
    {
        /// <summary>
        /// The command to execute.
        /// </summary>
        public string Command { get; }

        [JsonIgnore]
        public virtual bool HasArguments => false;
        public Request(string command)
            : base("request")
        {
            Command = command;
        }
    }

    /// <summary>
    /// A client or debug adapter initiated request.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Request<T> : Request
    {
        /// <summary>
        /// Object containing arguments for the command.
        /// </summary>
        public T Arguments { get; }

        [JsonIgnore]
        public override bool HasArguments => true;
        public Request(string command, T args)
            : base(command)
        {
            Arguments = args;
        }
    }

}
