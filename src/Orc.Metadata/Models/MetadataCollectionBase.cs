namespace Orc.Metadata
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class MetadataCollectionBase : IMetadataCollection
    {
        public abstract IEnumerable<IMetadata> All { get; }

        public virtual IMetadata? GetMetadata(string propertyName)
        {
            return All.FirstOrDefault(x => string.Equals(x.Name, propertyName));
        }

        IEnumerator<IMetadata> IEnumerable<IMetadata>.GetEnumerator()
        {
            return All.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return All.GetEnumerator();
        }
    }
}
