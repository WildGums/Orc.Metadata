namespace Orc.Metadata;

using Catel.Reflection;

public class FastMemberInvokerObjectWithMetadata : ObjectWithMetadata
{
    public FastMemberInvokerObjectWithMetadata(object instance, IFastMemberInvoker memberInvoker)
        : base(instance, new FastMemberInvokerMetadataCollection(memberInvoker, instance.GetType()))
    {
    }
}
