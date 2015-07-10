// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectWithMetadataExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Collections.Generic;
    using Catel;

    public static class IObjectWithMetadataExtensions
    {
        public static List<IMetadataValue> ToStaticMetadata(this IObjectWithMetadata objectWithMetadata)
        {
            Argument.IsNotNull(() => objectWithMetadata);

            var list = new List<IMetadataValue>();

            foreach (var metadata in objectWithMetadata.MetadataCollection)
            {
                var value = metadata.GetValue(objectWithMetadata.Instance);

                var metadataValue = new MetadataValue(metadata);

                var subObjectWithMetadata = value as IObjectWithMetadata;
                if (subObjectWithMetadata != null)
                {
                    metadataValue.Value = subObjectWithMetadata.ToStaticMetadata();
                }
                else
                {
                    metadataValue.Value = objectWithMetadata.GetMetadataValue(metadata.Name);
                }

                list.Add(metadataValue);
            }

            return list;
        }
    }
}