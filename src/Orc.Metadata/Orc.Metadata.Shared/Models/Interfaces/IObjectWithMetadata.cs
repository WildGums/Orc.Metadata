// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectWithMetadata.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public interface IObjectWithMetadata
    {
        object Instance { get; }
        IMetadataCollection MetadataCollection { get; }

        object GetMetadataValue(string key);
        bool SetMetadataValue(string key, object value);
    }
}