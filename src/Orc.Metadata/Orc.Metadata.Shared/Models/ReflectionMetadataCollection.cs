// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionMetadataCollection.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Catel;
    using Catel.Caching;
    using Catel.Reflection;

    public class ReflectionMetadataCollection : MetadataCollectionBase
    {
        #region Fields
        private static readonly ICacheStorage<Type, IEnumerable<IMetadata>> _metadataCache = new CacheStorage<Type, IEnumerable<IMetadata>>();
        private readonly IEnumerable<IMetadata> _all;
        #endregion

        #region Constructors
        public ReflectionMetadataCollection(Type type)
        {
            Argument.IsNotNull(() => type);

            _all = _metadataCache.GetFromCacheOrFetch(type, () => type.GetPropertiesEx().Select(x => new ReflectionMetadata(x)).ToArray());
        }
        #endregion

        #region Properties
        public override IEnumerable<IMetadata> All
        {
            get { return _all; }
        }
        #endregion
    }
}