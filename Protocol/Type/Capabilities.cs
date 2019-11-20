namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Information about the capabilities of a debug adapter.</para>
    /// </summary>
    public class Capabilities
    {
        /// <summary>
        /// <para>The debug adapter supports the 'configurationDone' request.</para>
        /// </summary>
        public bool? SupportsConfigurationDoneRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports function breakpoints.</para>
        /// </summary>
        public bool? SupportsFunctionBreakpoints { get; }
        /// <summary>
        /// <para>The debug adapter supports conditional breakpoints.</para>
        /// </summary>
        public bool? SupportsConditionalBreakpoints { get; }
        /// <summary>
        /// <para>The debug adapter supports breakpoints that break execution after a specified number of hits.</para>
        /// </summary>
        public bool? SupportsHitConditionalBreakpoints { get; }
        /// <summary>
        /// <para>The debug adapter supports a (side effect free) evaluate request for data hovers.</para>
        /// </summary>
        public bool? SupportsEvaluateForHovers { get; }
        /// <summary>
        /// <para>Available filters or options for the setExceptionBreakpoints request.</para>
        /// </summary>
        public ExceptionBreakpointsFilter[] ExceptionBreakpointFilters { get; }
        /// <summary>
        /// <para>The debug adapter supports stepping back via the 'stepBack' and 'reverseContinue' requests.</para>
        /// </summary>
        public bool? SupportsStepBack { get; }
        /// <summary>
        /// <para>The debug adapter supports setting a variable to a value.</para>
        /// </summary>
        public bool? SupportsSetVariable { get; }
        /// <summary>
        /// <para>The debug adapter supports restarting a frame.</para>
        /// </summary>
        public bool? SupportsRestartFrame { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'gotoTargets' request.</para>
        /// </summary>
        public bool? SupportsGotoTargetsRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'stepInTargets' request.</para>
        /// </summary>
        public bool? SupportsStepInTargetsRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'completions' request.</para>
        /// </summary>
        public bool? SupportsCompletionsRequest { get; }
        /// <summary>
        /// <para>The set of characters that should trigger completion in a REPL. If not specified, the UI should assume the '.' character.</para>
        /// </summary>
        public string[] CompletionTriggerCharacters { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'modules' request.</para>
        /// </summary>
        public bool? SupportsModulesRequest { get; }
        /// <summary>
        /// <para>The set of additional module information exposed by the debug adapter.</para>
        /// </summary>
        public ColumnDescriptor[] AdditionalModuleColumns { get; }
        /// <summary>
        /// <para>Checksum algorithms supported by the debug adapter.</para>
        /// </summary>
        public ChecksumAlgorithm[] SupportedChecksumAlgorithms { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'restart' request. In this case a client should not implement 'restart' by terminating and relaunching the adapter but by calling the RestartRequest.</para>
        /// </summary>
        public bool? SupportsRestartRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports 'exceptionOptions' on the setExceptionBreakpoints request.</para>
        /// </summary>
        public bool? SupportsExceptionOptions { get; }
        /// <summary>
        /// <para>The debug adapter supports a 'format' attribute on the stackTraceRequest, variablesRequest, and evaluateRequest.</para>
        /// </summary>
        public bool? SupportsValueFormattingOptions { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'exceptionInfo' request.</para>
        /// </summary>
        public bool? SupportsExceptionInfoRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'terminateDebuggee' attribute on the 'disconnect' request.</para>
        /// </summary>
        public bool? SupportTerminateDebuggee { get; }
        /// <summary>
        /// <para>The debug adapter supports the delayed loading of parts of the stack, which requires that both the 'startFrame' and 'levels' arguments and the 'totalFrames' result of the 'StackTrace' request are supported.</para>
        /// </summary>
        public bool? SupportsDelayedStackTraceLoading { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'loadedSources' request.</para>
        /// </summary>
        public bool? SupportsLoadedSourcesRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports logpoints by interpreting the 'logMessage' attribute of the SourceBreakpoint.</para>
        /// </summary>
        public bool? SupportsLogPoints { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'terminateThreads' request.</para>
        /// </summary>
        public bool? SupportsTerminateThreadsRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'setExpression' request.</para>
        /// </summary>
        public bool? SupportsSetExpression { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'terminate' request.</para>
        /// </summary>
        public bool? SupportsTerminateRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports data breakpoints.</para>
        /// </summary>
        public bool? SupportsDataBreakpoints { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'readMemory' request.</para>
        /// </summary>
        public bool? SupportsReadMemoryRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'disassemble' request.</para>
        /// </summary>
        public bool? SupportsDisassembleRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'cancel' request.</para>
        /// </summary>
        public bool? SupportsCancelRequest { get; }
        /// <summary>
        /// <para>The debug adapter supports the 'breakpointLocations' request.</para>
        /// </summary>
        public bool? SupportsBreakpointLocationsRequest { get; }
        public Capabilities(
        bool? supportsConfigurationDoneRequest = null,
        bool? supportsFunctionBreakpoints = null,
        bool? supportsConditionalBreakpoints = null,
        bool? supportsHitConditionalBreakpoints = null,
        bool? supportsEvaluateForHovers = null,
        ExceptionBreakpointsFilter[] exceptionBreakpointFilters = null,
        bool? supportsStepBack = null,
        bool? supportsSetVariable = null,
        bool? supportsRestartFrame = null,
        bool? supportsGotoTargetsRequest = null,
        bool? supportsStepInTargetsRequest = null,
        bool? supportsCompletionsRequest = null,
        string[] completionTriggerCharacters = null,
        bool? supportsModulesRequest = null,
        ColumnDescriptor[] additionalModuleColumns = null,
        ChecksumAlgorithm[] supportedChecksumAlgorithms = null,
        bool? supportsRestartRequest = null,
        bool? supportsExceptionOptions = null,
        bool? supportsValueFormattingOptions = null,
        bool? supportsExceptionInfoRequest = null,
        bool? supportTerminateDebuggee = null,
        bool? supportsDelayedStackTraceLoading = null,
        bool? supportsLoadedSourcesRequest = null,
        bool? supportsLogPoints = null,
        bool? supportsTerminateThreadsRequest = null,
        bool? supportsSetExpression = null,
        bool? supportsTerminateRequest = null,
        bool? supportsDataBreakpoints = null,
        bool? supportsReadMemoryRequest = null,
        bool? supportsDisassembleRequest = null,
        bool? supportsCancelRequest = null,
        bool? supportsBreakpointLocationsRequest = null
        )
        {
            SupportsConfigurationDoneRequest = supportsConfigurationDoneRequest;
            SupportsFunctionBreakpoints = supportsFunctionBreakpoints;
            SupportsConditionalBreakpoints = supportsConditionalBreakpoints;
            SupportsHitConditionalBreakpoints = supportsHitConditionalBreakpoints;
            SupportsEvaluateForHovers = supportsEvaluateForHovers;
            ExceptionBreakpointFilters = exceptionBreakpointFilters;
            SupportsStepBack = supportsStepBack;
            SupportsSetVariable = supportsSetVariable;
            SupportsRestartFrame = supportsRestartFrame;
            SupportsGotoTargetsRequest = supportsGotoTargetsRequest;
            SupportsStepInTargetsRequest = supportsStepInTargetsRequest;
            SupportsCompletionsRequest = supportsCompletionsRequest;
            CompletionTriggerCharacters = completionTriggerCharacters;
            SupportsModulesRequest = supportsModulesRequest;
            AdditionalModuleColumns = additionalModuleColumns;
            SupportedChecksumAlgorithms = supportedChecksumAlgorithms;
            SupportsRestartRequest = supportsRestartRequest;
            SupportsExceptionOptions = supportsExceptionOptions;
            SupportsValueFormattingOptions = supportsValueFormattingOptions;
            SupportsExceptionInfoRequest = supportsExceptionInfoRequest;
            SupportTerminateDebuggee = supportTerminateDebuggee;
            SupportsDelayedStackTraceLoading = supportsDelayedStackTraceLoading;
            SupportsLoadedSourcesRequest = supportsLoadedSourcesRequest;
            SupportsLogPoints = supportsLogPoints;
            SupportsTerminateThreadsRequest = supportsTerminateThreadsRequest;
            SupportsSetExpression = supportsSetExpression;
            SupportsTerminateRequest = supportsTerminateRequest;
            SupportsDataBreakpoints = supportsDataBreakpoints;
            SupportsReadMemoryRequest = supportsReadMemoryRequest;
            SupportsDisassembleRequest = supportsDisassembleRequest;
            SupportsCancelRequest = supportsCancelRequest;
            SupportsBreakpointLocationsRequest = supportsBreakpointLocationsRequest;
        }
    }
}
