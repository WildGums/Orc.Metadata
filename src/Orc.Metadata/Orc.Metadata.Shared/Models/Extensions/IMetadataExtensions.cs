// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public static class IMetadataExtensions
    {
        public static TValue GetValue<TValue>(this IMetadata metadata, object instance)
        {
            return (TValue) metadata.GetValue(instance);
        }
    }
}