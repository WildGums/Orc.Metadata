namespace Orc.Metadata;

using System;
using System.Collections.Generic;

public static class IObjectWithMetadataExtensions
{
    public static Dictionary<string, IMetadataValue> ToStaticMetadataDictionary(this IObjectWithMetadata objectWithMetadata)
    {
        ArgumentNullException.ThrowIfNull(objectWithMetadata);

        var dictionary = new Dictionary<string, IMetadataValue>();

        foreach (var metadata in objectWithMetadata.MetadataCollection)
        {
            if (!objectWithMetadata.TryGetMetadataValue(metadata.Name, out var value))
            {
                continue;
            }

            var metadataValue = new MetadataValue(metadata);

            if (value is IObjectWithMetadata subObjectWithMetadata)
            {
                metadataValue.ObjectValue = subObjectWithMetadata.ToStaticMetadataDictionary();
            }
            else
            {
                metadataValue.ObjectValue = value;
            }

            dictionary.Add(metadata.Name, metadataValue);
        }

        return dictionary;
    }

    public static List<IMetadataValue> ToStaticMetadataList(this IObjectWithMetadata objectWithMetadata)
    {
        ArgumentNullException.ThrowIfNull(objectWithMetadata);

        var metadataDictionary = objectWithMetadata.ToStaticMetadataDictionary();
        return metadataDictionary.ToStaticMetadataList();
    }

    public static List<IMetadataValue> ToStaticMetadataList(this Dictionary<string, IMetadataValue> metadataDictionary)
    {
        ArgumentNullException.ThrowIfNull(metadataDictionary);

        var list = new List<IMetadataValue>();

        foreach (var metadataKeyValuePair in metadataDictionary)
        {
            var value = metadataKeyValuePair.Value;

            if (value.ObjectValue is Dictionary<string, IMetadataValue> dictionary)
            {
                value.ObjectValue = dictionary.ToStaticMetadataList();
            }

            list.Add(value);
        }

        return list;
    }
}
