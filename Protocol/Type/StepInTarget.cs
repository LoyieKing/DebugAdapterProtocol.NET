namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A StepInTarget can be used in the ‘stepIn’ request and determines into which single target the stepIn request should step.</para>
    /// </summary>
    public class StepInTarget
    {
        /// <summary>
        /// <para>Unique identifier for a stepIn target.</para>
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// <para>The name of the stepIn target (shown in the UI).</para>
        /// </summary>
        public string Label { get; }
        public StepInTarget(long id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}
