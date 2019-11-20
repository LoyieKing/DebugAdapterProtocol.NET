# DebugAdapterProtocol.NET

Visual Studio Code DebugAdapterProtocol written in C#(.NET Standard)

## Usage

```C#
Server = new ProtocolServer(InputStream,OutputStream);
Server
    .RegisterProtocolMessage<InitializeRequest>(OnInitialize)
    .RegisterProtocolMessage<DisconnectRequest>(OnDisconnect)
    .RegisterProtocolMessage<LaunchRequest>(OnLaunch)

    .RegisterProtocolMessage<SetBreakpointsRequest>(OnSetBreakpoints)
    .RegisterProtocolMessage<SetExceptionBreakpointsRequest>(OnSetExceptionBreakpoints)
    .RegisterProtocolMessage<ConfigurationDoneRequest>(OnConfigurationDone)
    .RegisterProtocolMessage<SourceRequest>(OnSource)

    .RegisterProtocolMessage<ThreadsRequest>(OnThreads)
    .RegisterProtocolMessage<StackTraceRequest>(OnStackTrace)
    .RegisterProtocolMessage<ScopesRequest>(OnScopes)
    .RegisterProtocolMessage<VariablesRequest>(OnVariables)

    .RegisterProtocolMessage<EvaluateRequest>(OnEvaluate)

    .RegisterProtocolMessage<ContinueRequest>(OnContinue)
    .RegisterProtocolMessage<NextRequest>(OnNext)
    .RegisterProtocolMessage<StepInRequest>(OnStepIn)
    .RegisterProtocolMessage<PauseRequest>(OnPause)
    .Start().Wait()
    ;
```

```C#
private void OnInitialize(ProtocolServer server, InitializeRequest request)
{
    Capabilities capabilities = new Capabilities(
        supportsSetVariable: true,
        supportsRestartRequest: false,
        supportsEvaluateForHovers:false,
        supportsConfigurationDoneRequest:true,
        supportsFunctionBreakpoints:true
        );

    InitializeResponse response = new InitializeResponse(request, true, capabilities);
    server.SendMessage(response);
}
```

## TODO

- [ ] Add OnRequestDelegateHandler and OnRequestHandler

- More...
