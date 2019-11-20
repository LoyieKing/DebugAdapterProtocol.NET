namespace DebugAdapterProtocol.Protocol.Type
{
    public enum SourcePresentationHint
    {
        Normal,
        Emphasize,
        Deemphasize
    }

    public enum StackFramePresentationHint
    {
        Normal,
        Label,
        Subtle
    }

    public enum ScopePresentationHint
    {
        Arguments,
        Locals,
        Registers
    }
}
