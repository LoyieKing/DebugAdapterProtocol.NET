using DebugAdapterProtocol.Protocol.Event;
using DebugAdapterProtocol.Protocol.ReverseRequest;
using DebugAdapterProtocol.Protocol.Type;
using System;
using System.Collections.Generic;
using System.Text;
using static DebugAdapterProtocol.Protocol.Event.OutputEvent.OutputEventBody;

namespace DebugAdapterProtocol.Server
{
    public static class ServerSendEvent
    {

        /// <summary>
        /// <para>The event indicates that some information about a breakpoint has changed.</para>
        /// </summary>
        /// <param name="reason">
        /// <para>The reason for the event.</para>
        /// <para>Values: 'changed', 'new', 'removed', etc.</para>
        /// </param>
        /// <param name="breakpoint">
        /// <para>The 'id' attribute is used to find the target breakpoint and the other attributes are used as the new values.</para>
        /// </param>
        public static void SendBreakpointEvent(this ProtocolServer server,EventReason reason, Breakpoint breakpoint)
        {
            BreakpointEvent breakpointEvent = new BreakpointEvent(new BreakpointEvent.BreakpointEventBody(reason, breakpoint));
            server.SendMessage(breakpointEvent);
        }

        /// <summary>
        /// <para>The event indicates that one or more capabilities have changed.</para>
        /// <para>Since the capabilities are dependent on the frontend and its UI, it might not be possible to change that at random times (or too late).</para>
        /// <para>Consequently this event has a hint characteristic: a frontend can only be expected to make a ‘best effort’ in honouring individual capabilities but there are no guarantees.</para>
        /// <para>Only changed capabilities need to be included, all other capabilities keep their values.</para>
        /// </summary>
        /// <param name="capabilities"><para>The set of updated capabilities.</para></param>
        public static void SendCapabilitiesEvent(this ProtocolServer server,Capabilities capabilities)
        {
            CapabilitiesEvent capabilitiesEvent = new CapabilitiesEvent(new CapabilitiesEvent.CapabilitiesEventBody(capabilities));
            server.SendMessage(capabilitiesEvent);
        }

        /// <summary>
        /// <para>The event indicates that the execution of the debuggee has continued.</para>
        /// <para>Please note: a debug adapter is not expected to send this event in response to a request that implies that execution continues, e.g. ‘launch’ or ‘continue’.</para>
        /// <para>It is only necessary to send a ‘continued’ event if there was no previous request that implied this.</para>
        /// </summary>
        /// <param name="threadId"><para>The thread which was continued.</para></param>
        /// <param name="allThreadsContinued"><para>If 'allThreadsContinued' is true, a debug adapter can announce that all threads have continued.</para></param>
        public static void SendContinuedEvent(this ProtocolServer server,long threadId, bool? allThreadsContinued = null)
        {
            ContinuedEvent continuedEvent = new ContinuedEvent(new ContinuedEvent.ContinuedEventBody(threadId, allThreadsContinued));
            server.SendMessage(continuedEvent);
        }

        /// <summary>
        /// <para>The event indicates that the debuggee has exited and returns its exit code.</para>
        /// </summary>
        /// <param name="exitCode"><para>The exit code returned from the debuggee.</para></param>
        public static void SendExitedEvent(this ProtocolServer server,long exitCode)
        {
            ExitedEvent exitedEvent = new ExitedEvent(new ExitedEvent.ExitedEventBody(exitCode));
            server.SendMessage(exitedEvent);
        }

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
        public static void SendInitializedEvent(this ProtocolServer server)
        {
            InitializedEvent initializedEvent = new InitializedEvent();
            server.SendMessage(initializedEvent);
        }

        /// <summary>
        /// <para>The event indicates that some source has been added, changed, or removed from the set of all loaded sources.</para>
        /// </summary>
        /// <param name="reason"><para>The reason for the event.</para></param>
        /// <param name="source"><para>The new, changed, or removed source.</para></param>
        public static void SendLoadedSourceEvent(this ProtocolServer server,EventReason reason, Source source)
        {
            LoadedSourceEvent loadedSourceEvent = new LoadedSourceEvent(new LoadedSourceEvent.LoadedSourceEventBody(reason, source));
            server.SendMessage(loadedSourceEvent);
        }

        /// <summary>
        /// <para>The event indicates that some information about a module has changed.</para>
        /// </summary>
        /// <param name="eventReason"><para>The reason for the event.</para></param>
        /// <param name="module"><para>The new, changed, or removed module. In case of 'removed' only the module id is used.</para></param>
        public static void SendModuleEvent(this ProtocolServer server,EventReason eventReason, Module module)
        {
            ModuleEvent moduleEvent = new ModuleEvent(new ModuleEvent.ModuleEventBody(eventReason, module));
            server.SendMessage(moduleEvent);
        }

        /// <summary>
        /// <para>The event indicates that the target has produced some output.</para>
        /// </summary>
        /// <param name="output">
        /// <para>The output to report.</para>
        /// </param>
        /// <param name="category">
        /// <para>The output category. If not specified, 'console' is assumed.</para>
        /// <para>Values: 'console', 'stdout', 'stderr', 'telemetry', etc.</para></param>
        /// <param name="variablesReference">
        /// <para>If an attribute 'variablesReference' exists and its value is > 0, the output contains objects which can be retrieved by passing 'variablesReference' to the 'variables' request. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
        /// </param>
        /// <param name="source"><para>An optional source location where the output was produced.</para></param>
        /// <param name="line"><para>An optional source location line where the output was produced.</para></param>
        /// <param name="column"><para>An optional source location column where the output was produced.</para></param>
        /// <param name="data"><para>Optional data to report. For the 'telemetry' category the data will be sent to telemetry, for the other categories the data is shown in JSON format.</para></param>
        public static void SendOutputEvent(this ProtocolServer server,
            string output,
            OutputCategory category = OutputCategory.Console,
            long? variablesReference = null,
            Source source = null,
            long? line = null,
            long? column = null,
            Dictionary<string, object> data = null)
        {
            OutputEvent outputEvent = new OutputEvent(new OutputEvent.OutputEventBody(
                output,
                category,
                variablesReference,
                source,
                line,
                column,
                data
                ));
            server.SendMessage(outputEvent);
        }

        /// <summary>
        /// <para>The event indicates that the debugger has begun debugging a new process. Either one that it has launched, or one that it has attached to.</para>
        /// </summary>
        /// <param name="name"><para>The logical name of the process. This is usually the full path to process's executable file. Example: /home/example/myproj/program.js.</para></param>
        /// <param name="systemProcessId"><para>The system process id of the debugged process. This property will be missing for non-system processes.</para></param>
        /// <param name="isLocalProcess"><para>If true, the process is running on the same computer as the debug adapter.</para></param>
        /// <param name="startMethod">
        /// <para>Describes how the debug engine started debugging this process.</para>
        /// <para>'launch': Process was launched under the debugger.</para>
        /// <para>'attach': Debugger attached to an existing process.</para>
        /// <para>'attachForSuspendedLaunch': A project launcher component has launched a new process in a suspended state and then asked the debugger to attach.</para>
        /// </param>
        /// <param name="pointerSize">
        /// <para>The size of a pointer or address for this process, in bits. This value may be used by clients when formatting addresses for display.</para>
        /// </param>
        public static void SendProcessEvent(this ProtocolServer server,
            string name,
            long? systemProcessId = null,
            bool? isLocalProcess = null,
            StartMethod? startMethod = null,
            long? pointerSize = null)
        {
            ProcessEvent processEvent = new ProcessEvent(new ProcessEvent.ProcessEventBody(name, systemProcessId, isLocalProcess, startMethod, pointerSize));
            server.SendMessage(processEvent);
        }

        /// <summary>
        /// <para>The event indicates that the execution of the debuggee has stopped due to some condition.</para>
        /// <para>This can be caused by a break point previously set, a stepping action has completed, by executing a debugger statement etc.</para>
        /// </summary>
        /// <param name="reason">
        /// <para>The reason for the event.</para>
        /// <para>For backward compatibility this string is shown in the UI if the 'description' attribute is missing (but it must not be translated).</para>
        /// <para>Values: 'step', 'breakpoint', 'exception', 'pause', 'entry', 'goto', 'function breakpoint', 'data breakpoint', etc.</para>
        /// </param>
        /// <param name="description">The full reason for the event, e.g. 'Paused on exception'. This string is shown in the UI as is and must be translated.</param>
        /// <param name="threadId">The thread which was stopped.</param>
        /// <param name="preserveFocusHint">A value of true hints to the frontend that this event should not change the focus.</param>
        /// <param name="text">Additional information. E.g. if reason is 'exception', text contains the exception name. This string is shown in the UI.</param>
        /// <param name="allThreadsStopped">
        /// <para>If 'allThreadsStopped' is true, a debug adapter can announce that all threads have stopped.</para>
        /// <para>- The client should use this information to enable that all threads can be expanded to access their stacktraces.</para>
        /// <para>- If the attribute is missing or false, only the thread with the given threadId can be expanded.</para>
        /// </param>
        public static void SendStoppedEvent(this ProtocolServer server,
                string reason,
                string description = null,
                long? threadId = null,
                bool? preserveFocusHint = null,
                string text = null,
                bool? allThreadsStopped = null
            )
        {
            StoppedEvent stoppedEvent = new StoppedEvent(new StoppedEvent.StoppedEventBody(reason, description, threadId, preserveFocusHint, text, allThreadsStopped));
            server.SendMessage(stoppedEvent);
        }

        /// <summary>
        /// <para>The event indicates that debugging of the debuggee has terminated. This does not mean that the debuggee itself has exited.</para>
        /// </summary>
        public static void SendTerminatedEvent(this ProtocolServer server)
        {
            TerminatedEvent terminatedEvent = new TerminatedEvent();
            server.SendMessage(terminatedEvent);
        }

        /// <summary>
        /// <para>The event indicates that debugging of the debuggee has terminated. This does not mean that the debuggee itself has exited.</para>
        /// </summary>
        /// <param name="body">
        /// <para>A debug adapter may set 'restart' to true (or to an arbitrary object) to request that the front end restarts the session.</para>
        /// <para>The value is not interpreted by the client and passed unmodified as an attribute '__restart' to the 'launch' and 'attach' requests.</para>
        /// </param>
        public static void SendTerminatedEvent(this ProtocolServer server,Dictionary<string, object> restart = null)
        {
            TerminatedEvent terminatedEvent = new TerminatedEvent(new TerminatedEvent.TerminatedEventBody(restart));
            server.SendMessage(terminatedEvent);
        }

        /// <summary>
        /// <para>The event indicates that a thread has started or exited.</para>
        /// </summary>
        /// <param name="reason">
        /// <para>The reason for the event.</para>
        /// <para>Values: 'started', 'exited', etc.</para>
        /// </param>
        /// <param name="threadId"><para>The identifier of the thread.</para></param>
        public static void SendThreadEvent(this ProtocolServer server,string reason, long threadId)
        {
            ThreadEvent threadEvent = new ThreadEvent(new ThreadEvent.ThreadEventBody(reason, threadId));
            server.SendMessage(threadEvent);
        }

        public static void SendRunInTerminalRequest(this ProtocolServer server, RunInTerminalRequestArguments args)
        {
            server.SendMessage(new RunInTerminalRequest(args));
        }
    }
}
