using System.Collections.Generic;

namespace DebugAdapterProtocol.Protocol.Type
{
    /// <summary>
    /// <para>A Source is a descriptor for source code. It is returned from the debug adapter as part of a StackFrame and it is used by clients when specifying breakpoints.</para>
    /// </summary>
    public class Source
    {
        /// <summary>
        /// <para>The short name of the source. Every source returned from the debug adapter has a name. When sending a source to the debug adapter this name is optional.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// <para>The path of the source to be shown in the UI. It is only used to locate and load the content of the source if no sourceReference is specified (or its value is 0).</para>
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// <para>If sourceReference > 0 the contents of the source must be retrieved through the SourceRequest (even if a path is specified). A sourceReference is only valid for a session, so it must not be used to persist a source. The value should be less than or equal to 2147483647 (2^31 - 1).</para>
        /// </summary>
        public int? SourceReference { get; }
        /// <summary>
        /// <para>An optional hint for how to present the source in the UI. A value of 'deemphasize' can be used to indicate that the source is not available or that it is skipped on stepping.</para>
        /// </summary>
        public SourcePresentationHint? PresentationHint { get; }
        /// <summary>
        /// <para>The (optional) origin of this source: possible values 'internal module', 'inlined content from source map', etc.</para>
        /// </summary>
        public string Origin { get; }
        /// <summary>
        /// <para>An optional list of sources that are related to this source. These may be the source that generated this source.</para>
        /// </summary>
        public Source[] Sources { get; }
        /// <summary>
        /// <para>Optional data that a debug adapter might want to loop through the client. The client should leave the data intact and persist it across sessions. The client should not interpret the data.</para>
        /// </summary>
        public Dictionary<string, object> AdapterData { get; }
        /// <summary>
        /// <para>The checksums associated with this file.</para>
        /// </summary>
        public Checksum[] Checksums { get; }
        public Source(
            string name,
            string path = null,
            int? sourceReference = null,
            SourcePresentationHint? presentationHint = null,
            string origin = null,
            Source[] sources = null,
            Dictionary<string, object> adapterData = null,
            Checksum[] checksums = null)
        {
            Name = name;
            Path = path;
            SourceReference = sourceReference;
            PresentationHint = presentationHint;
            Origin = origin;
            Sources = sources;
            AdapterData = adapterData;
            Checksums = checksums;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Source source))
                return false;

            var thisRef = SourceReference.GetValueOrDefault(0);
            var thatRef = SourceReference.GetValueOrDefault(0);
            if (thisRef > 0 && thisRef == thatRef)
                return true;
            return Path != null && Path == source.Path;
        }
    }
}
