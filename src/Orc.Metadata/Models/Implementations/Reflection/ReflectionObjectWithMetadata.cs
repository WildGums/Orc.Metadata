namespace Orc.Metadata;

public class ReflectionObjectWithMetadata : ObjectWithMetadata
{
    public ReflectionObjectWithMetadata(object instance)
        : base(instance, new ReflectionMetadataCollection(instance.GetType()))
    {
    }
}
