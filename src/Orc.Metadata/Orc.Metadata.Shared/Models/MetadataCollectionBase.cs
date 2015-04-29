﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataCollectionBase.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class MetadataCollectionBase : IMetadataCollection
    {
        public abstract IEnumerable<IMetadata> All { get; }

        public IMetadata GetMetadata(string metadataName)
        {
            return All.FirstOrDefault(x => string.Equals(x.Name, metadataName));
        }
    }
}