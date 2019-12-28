namespace Orc.Metadata.Providers
{
    using System;
    using System.Threading.Tasks;
    using Catel.Caching;
    using Catel.Reflection;
    using Catel.Threading;

    public class FastMemberInvokerMetadataProvider : IMetadataProvider
    {
        private static readonly ICacheStorage<Type, IFastMemberInvoker> MemberInvokerCache = new CacheStorage<Type, IFastMemberInvoker>();
        private static readonly ICacheStorage<Type, Type> MemberInvokerTypeCache = new CacheStorage<Type, Type>();

        public Task<IObjectWithMetadata> GetMetadataAsync(object obj)
        {
            var memberInvoker = GetMemberInvoker(obj);

            return TaskHelper<IObjectWithMetadata>.FromResult(new FastMemberInvokerObjectWithMetadata(obj, memberInvoker));
        }

        private IFastMemberInvoker GetMemberInvoker(object obj)
        {
            var invokerType = MemberInvokerTypeCache.GetFromCacheOrFetch(obj.GetType(), () => typeof(FastMemberInvoker<>).MakeGenericType(obj.GetType()));

            return MemberInvokerCache.GetFromCacheOrFetch(invokerType, () => (IFastMemberInvoker)Activator.CreateInstance(invokerType));
        }
    }
}
