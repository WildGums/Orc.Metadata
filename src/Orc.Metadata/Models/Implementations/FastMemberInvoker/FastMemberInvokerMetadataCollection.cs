namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Catel;
    using Catel.Caching;
    using Catel.Reflection;

    public class FastMemberInvokerMetadataCollection : MetadataCollectionBase
    {
        private static readonly ICacheStorage<Type, IEnumerable<IMetadata>> MetadataCache = new CacheStorage<Type, IEnumerable<IMetadata>>();
        private readonly IEnumerable<IMetadata> _all;

        public FastMemberInvokerMetadataCollection(IFastMemberInvoker memberInvoker, Type type)
        {
            ArgumentNullException.ThrowIfNull(memberInvoker);
            ArgumentNullException.ThrowIfNull(type);

            // Note: maybe support Fields as well

            _all = MetadataCache.GetFromCacheOrFetch(type, () => type.GetPropertiesEx()
                .Select(x => new FastMemberInvokerMetadata(memberInvoker, x.Name, x.PropertyType)).ToArray());
        }

        public override IEnumerable<IMetadata> All => _all;
    }
}
