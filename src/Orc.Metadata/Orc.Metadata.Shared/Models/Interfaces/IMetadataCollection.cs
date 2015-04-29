// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataCollection.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Collections.Generic;

    public interface IMetadataCollection
    {
        IEnumerable<IMetadata> All { get; }

        IMetadata GetMetadata(string propertyName);
    }
}