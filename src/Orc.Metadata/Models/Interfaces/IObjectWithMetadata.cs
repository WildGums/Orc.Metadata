// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectWithMetadata.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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