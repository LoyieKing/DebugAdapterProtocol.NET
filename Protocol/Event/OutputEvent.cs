using DebugAdapterProtocol.Protocol.Type;
using System.Collections.Generic;

namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>The event indicates that the target has produced some output.</para>
    /// </summary>
    public class OutputEvent : BaseProtocol.Event<OutputEvent.OutputEventBody>
    {
        public class OutputEventBody
        {
            public enum OutputCategory
            {
                Console,
                Stdout,
                Stderr,
                Telemetry
            }
            /// <summary>
            /// <para>The output category. If not specified, 'console' is assumed.</para>
            /// <para>Values: 'console', 'stdout', 'stderr', 'telemetry', etc.</para>
            /// </summary>
            public OutputCategory Category { get; }
            /// <summary>
            /// <para>The output to report.</para>
            /// </summary>
            public string Output { get; }
            /// <summary>
            /// <para>If an attribute 'variablesReference' exists and its value is > 0, the output contains objects which can be retrieved by passing 'variablesReference' to the 'variables' request. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
            /// </summary>
            public long? VariablesReference { get; }
            /// <summary>
            /// <para>An optional source location where the output was produced.</para>
            /// </summary>
            public Source Source { get; }
            /// <summary>
            /// <para>An optional source location line where the output was produced.</para>
            /// </summary>
            public long? Line { get; }
            /// <summary>
            /// <para>An optional source location column where the output was produced.</para>
            /// </summary>
            public long? Column { get; }
            /// <summary>
            /// <para>Optional data to report. For the 'telemetry' category the data will be sent to telemetry, for the other categories the data is shown in JSON format.</para>
            /// </summary>
            public Dictionary<string, object> Data { get; }
            public OutputEventBody(string output, OutputCategory category = OutputCategory.Console, long? variablesReference = null, Source source = null, long? line = null, long? column = null, Dictionary<string, object> data = null)
            {
                Category = category;
                Output = output;
                VariablesReference = variablesReference;
                Source = source;
                Line = line;
                Column = column;
                Data = data;
            }
        }
        public OutputEvent(OutputEventBody body)
            : base("output", body)
        {
        }
    }

}
