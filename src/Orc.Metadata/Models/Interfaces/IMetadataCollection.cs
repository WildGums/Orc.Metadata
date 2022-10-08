namespace Orc.Metadata
{
    using System.Collections.Generic;

    public interface IMetadataCollection : IEnumerable<IMetadata>
    {
        IEnumerable<IMetadata> All { get; }

        IMetadata? GetMetadata(string propertyName);
    }
}
