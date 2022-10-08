namespace Orc.Metadata
{
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

                var subObjectWithMetadata = value as IObjectWithMetadata;
                if (subObjectWithMetadata is not null)
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

                var dictionary = value.ObjectValue as Dictionary<string, IMetadataValue>;
                if (dictionary is not null)
                {
                    value.ObjectValue = dictionary.ToStaticMetadataList();
                }

                list.Add(value);
            }

            return list;
        }
    }
}
