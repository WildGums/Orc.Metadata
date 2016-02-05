// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataCollection.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IMetadataCollection : IEnumerable<IMetadata>
    {
        IEnumerable<IMetadata> All { get; }

        IMetadata GetMetadata(string propertyName);
    }
}