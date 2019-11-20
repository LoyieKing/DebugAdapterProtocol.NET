namespace DebugAdapterProtocol.Protocol.Event
{
    /// <summary>
    /// <para>This event indicates that the debug adapter is ready to accept configuration requests (e.g. SetBreakpointsRequest, SetExceptionBreakpointsRequest).</para>
    /// <para>A debug adapter is expected to send this event when it is ready to accept configuration requests (but not before the ‘initialize’ request has finished).</para>
    /// <para>The sequence of events/requests is as follows:</para>
    /// <list type="bullet">
    /// <item><description>adapters sends ‘initialized’ event (after the ‘initialize’ request has returned)</description></item>
    /// <item><description>frontend sends zero or more ‘setBreakpoints’ requests</description></item>
    /// <item><description>frontend sends one ‘setFunctionBreakpoints’ request</description></item>
    /// <item><description>frontend sends a ‘setExceptionBreakpoints’ request if one or more ‘exceptionBreakpointFilters’ have been defined (or if ‘supportsConfigurationDoneRequest’ is not defined or false)</description></item>
    /// <item><description>frontend sends other future configuration requests</description></item>
    /// <item><description>frontend sends one ‘configurationDone’ request to indicate the end of the configuration.</description></item>
    /// </list>
    /// </summary>
    public class InitializedEvent : BaseProtocol.Event
    {
        public InitializedEvent()
            : base("initialized")
        {
        }
    }
}
