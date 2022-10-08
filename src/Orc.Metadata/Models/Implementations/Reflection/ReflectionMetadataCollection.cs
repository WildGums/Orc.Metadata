namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Catel.Caching;
    using Catel.Reflection;

    public class ReflectionMetadataCollection : MetadataCollectionBase
    {
        private static readonly ICacheStorage<Type, IEnumerable<IMetadata>> MetadataCache = new CacheStorage<Type, IEnumerable<IMetadata>>();
        private readonly IEnumerable<IMetadata> _all;
  
        public ReflectionMetadataCollection(Type type)
        {
            ArgumentNullException.ThrowIfNull(type);

            _all = MetadataCache.GetFromCacheOrFetch(type, () => type.GetPropertiesEx().Select(x => new ReflectionMetadata(x)).ToArray());
        }

        public override IEnumerable<IMetadata> All
        {
            get { return _all; }
        }
    }
}
