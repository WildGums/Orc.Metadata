// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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