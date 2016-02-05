// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataCollectionBase.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class MetadataCollectionBase : IMetadataCollection
    {
        public abstract IEnumerable<IMetadata> All { get; }

        public virtual IMetadata GetMetadata(string metadataName)
        {
            return All.FirstOrDefault(x => string.Equals(x.Name, metadataName));
        }

        IEnumerator<IMetadata> IEnumerable<IMetadata>.GetEnumerator()
        {
            return All.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return All.GetEnumerator();
        }
    }
}