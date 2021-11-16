// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectWithMetadataExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Collections.Generic;
    using Catel;

    public static class IObjectWithMetadataExtensions
    {
        public static Dictionary<string, IMetadataValue> ToStaticMetadataDictionary(this IObjectWithMetadata objectWithMetadata)
        {
            Argument.IsNotNull(() => objectWithMetadata);

            var dictionary = new Dictionary<string, IMetadataValue>();

            foreach (var metadata in objectWithMetadata.MetadataCollection)
            {
                var value = objectWithMetadata.GetMetadataValue(metadata.Name);

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
            Argument.IsNotNull(() => objectWithMetadata);

            var metadataDictionary = objectWithMetadata.ToStaticMetadataDictionary();
            return metadataDictionary.ToStaticMetadataList();
        }

        public static List<IMetadataValue> ToStaticMetadataList(this Dictionary<string, IMetadataValue> metadataDictionary)
        {
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
