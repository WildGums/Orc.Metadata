namespace Orc.Metadata;

public class ObjectWithMetadata : IObjectWithMetadata
{
    public ObjectWithMetadata(object instance, IMetadataCollection metadataCollection)
    {
        Instance = instance;
        MetadataCollection = metadataCollection;
    }

    public object Instance { get; private set; }

    public IMetadataCollection MetadataCollection { get; private set; }

    public virtual bool TryGetMetadataValue(string key, out object? value)
    {
        return TryGetMetadataValueWithInstance(Instance, key, out value);
    }

    public virtual bool TrySetMetadataValue(string key, object? value)
    {
        return TrySetMetadataValueWithInstance(Instance, key, value);
    }

    protected bool TryGetMetadataValueWithInstance(object instance, string key, out object? value)
    {
        value = null;

        var metadata = MetadataCollection.GetMetadata(key);
        if (metadata is null)
        {
            return false;
        }

        return metadata.TryGetValue<object?>(instance, out value);
    }

    protected bool TrySetMetadataValueWithInstance(object instance, string key, object? value)
    {
        var metadata = MetadataCollection.GetMetadata(key);
        if (metadata is null)
        {
            return false;
        }

        metadata.TrySetValue(instance, value);
        return true;
    }
}
