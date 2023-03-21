namespace Orc.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;

public class DictionaryMetadataCollection : MetadataCollectionBase
{
    private readonly List<IMetadata> _metadata;

    public DictionaryMetadataCollection()
    {
        _metadata = new List<IMetadata>();
    }

    public DictionaryMetadataCollection(Dictionary<string, Type> dictionarySchema)
        : this()
    {
        ArgumentNullException.ThrowIfNull(dictionarySchema);

        _metadata = dictionarySchema.Select(kvp => new DictionaryMetadata(kvp.Key, kvp.Value)).Cast<IMetadata>().ToList();
    }

    public override IEnumerable<IMetadata> All
    {
        get { return _metadata; }
    }
}
