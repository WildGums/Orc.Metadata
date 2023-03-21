namespace Orc.Metadata;

using System;
using System.Threading.Tasks;
using Catel.Caching;
using Catel.Logging;
using Catel.Reflection;

public class FastMemberInvokerMetadataProvider : IMetadataProvider
{
    private static readonly ILog Log = LogManager.GetCurrentClassLogger();

    private static readonly ICacheStorage<Type, IFastMemberInvoker> MemberInvokerCache = new CacheStorage<Type, IFastMemberInvoker>();
    private static readonly ICacheStorage<Type, Type> MemberInvokerTypeCache = new CacheStorage<Type, Type>();

    public Task<IObjectWithMetadata> GetMetadataAsync(object obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var memberInvoker = GetMemberInvoker(obj);

        return Task.FromResult<IObjectWithMetadata>(new FastMemberInvokerObjectWithMetadata(obj, memberInvoker));
    }

    private static IFastMemberInvoker GetMemberInvoker(object obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var invokerType = MemberInvokerTypeCache.GetFromCacheOrFetch(obj.GetType(), () => typeof(FastMemberInvoker<>).MakeGenericType(obj.GetType()));

        return MemberInvokerCache.GetFromCacheOrFetch(invokerType, () =>
        {
            if (Activator.CreateInstance(invokerType) is not IFastMemberInvoker fastMemberInvoker)
            {
                throw Log.ErrorAndCreateException<InvalidOperationException>($"Cannot create fast member invoker for '{obj.GetType().GetSafeFullName()}'");
            }

            return fastMemberInvoker;
        });
    }
}
