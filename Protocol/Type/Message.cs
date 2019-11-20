using System.Collections.Generic;

namespace DebugAdapterProtocol.Protocol.Type
{
    public class Message
    {
        /// <summary>
        /// Unique identifier for the message.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// A format string for the message. Embedded variables have the form '{name}'.
        /// <para>If variable name starts with an underscore character, the variable does not contain user data (PII) and can be safely used for telemetry purposes.</para>
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// An object used as a dictionary for looking up the variables in the format string.
        /// </summary>
        public Dictionary<string, string> Variables { get; }

        /// <summary>
        /// If true send to telemetry.
        /// </summary>
        public bool? SendTelemetry { get; }

        /// <summary>
        /// If true show user.
        /// </summary>
        public bool? ShowUser { get; }

        /// <summary>
        /// An optional url where additional information about this message can be found.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// An optional label that is presented to the user as the UI for opening the url.
        /// </summary>
        public string UrlLabel { get; }

        public Message(
            long id,
            string format,
            Dictionary<string, string> variables = null,
            bool? sendTelemetry = null,
            bool? showUser = null,
            string url = null,
            string urlLabel = null)
        {
            Id = id;
            Format = format;
            Variables = variables;
            SendTelemetry = sendTelemetry;
            ShowUser = showUser;
            Url = url;
            UrlLabel = urlLabel;
        }
    }
}
