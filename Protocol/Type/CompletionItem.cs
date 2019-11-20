namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>CompletionItems are the suggestions returned from the CompletionsRequest.</para>
    /// </summary>
    public class CompletionItem
    {
        /// <summary>
        /// <para>The label of this completion item. By default this is also the text that is inserted when selecting this completion.</para>
        /// </summary>
        public string Label { get; }
        /// <summary>
        /// <para>If text is not falsy then it is inserted instead of the label.</para>
        /// </summary>
        public string Text { get; }
        /// <summary>
        /// <para>A string that should be used when comparing this item with other items. When `falsy` the label is used.</para>
        /// </summary>
        public string SortText { get; }
        /// <summary>
        /// <para>The item's type. Typically the client uses this information to render the item in the UI with an icon.</para>
        /// </summary>
        public CompletionItemType? Type { get; }
        /// <summary>
        /// <para>This value determines the location (in the CompletionsRequest's 'text' attribute) where the completion text is added.</para>
        /// <para>   If missing the text is added at the location specified by the CompletionsRequest's 'column' attribute.</para>
        /// </summary>
        public long? Start { get; }
        /// <summary>
        /// <para>This value determines how many characters are overwritten by the completion text.</para>
        /// <para>   If missing the value 0 is assumed which results in the completion text being inserted.</para>
        /// </summary>
        public long? Length { get; }
        public CompletionItem(
        string label,
        string text = null,
        string sortText = null,
        CompletionItemType? type = null,
        long? start = null,
        long? length = null
        )
        {
            Label = label;
            Text = text;
            SortText = sortText;
            Type = type;
            Start = start;
            Length = length;
        }
    }
}
