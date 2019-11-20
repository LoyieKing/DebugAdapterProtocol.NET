namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>Optional properties of a variable that can be used to determine how to render the variable in the UI.</para>
    /// </summary>
    public class VariablePresentationHint
    {
        /// <summary>
        /// <para>The kind of variable. Before introducing additional values, try to use the listed values.</para>
        /// <para>   Values: </para>
        /// <para>   'property': Indicates that the object is a property.</para>
        /// <para>   'method': Indicates that the object is a method.</para>
        /// <para>   'class': Indicates that the object is a class.</para>
        /// <para>   'data': Indicates that the object is data.</para>
        /// <para>   'event': Indicates that the object is an event.</para>
        /// <para>   'baseClass': Indicates that the object is a base class.</para>
        /// <para>   'innerClass': Indicates that the object is an inner class.</para>
        /// <para>   'interface': Indicates that the object is an interface.</para>
        /// <para>   'mostDerivedClass': Indicates that the object is the most derived class.</para>
        /// <para>   'virtual': Indicates that the object is virtual, that means it is a synthetic object introduced by the adapter for rendering purposes, e.g. an index range for large arrays.</para>
        /// <para>   'dataBreakpoint': Indicates that a data breakpoint is registered for the object.</para>
        /// <para>   etc.</para>
        /// </summary>
        public string Kind { get; }

        /// <summary>
        /// <para>Set of attributes represented as an array of strings. Before introducing additional values, try to use the listed values.</para>
        /// <para>   Values: </para>
        /// <para>   'static': Indicates that the object is static.</para>
        /// <para>   'constant': Indicates that the object is a constant.</para>
        /// <para>   'readOnly': Indicates that the object is read only.</para>
        /// <para>   'rawString': Indicates that the object is a raw string.</para>
        /// <para>   'hasObjectId': Indicates that the object can have an Object ID created for it.</para>
        /// <para>   'canHaveObjectId': Indicates that the object has an Object ID associated with it.</para>
        /// <para>   'hasSideEffects': Indicates that the evaluation had side effects.</para>
        /// <para>   etc.</para>
        /// </summary>
        public string[] Attributes { get; }
        /// <summary>
        /// <para>Visibility of variable. Before introducing additional values, try to use the listed values.</para>
        /// <para>   Values: 'public', 'private', 'protected', 'internal', 'final', etc.</para>
        /// </summary>
        public string Visibility { get; }
        public VariablePresentationHint(string kind = null, string[] attributes = null, string visibility = null)
        {
            Kind = kind;
            Attributes = attributes;
            Visibility = visibility;
        }
    }
}
