namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>This enumeration defines all possible conditions when a thrown exception should result in a break.  never: never breaks,  always: always breaks,  unhandled: breaks when exception unhandled,  userUnhandled: breaks if the exception is not handled by user code.  </para>
    /// </summary>
    public enum ExceptionBreakMode
    {
        Never,
        Always,
        Unhandled,
        UserUnhandled
    }
}
