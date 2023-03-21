namespace Orc.Metadata;

public interface IObjectWithMetadata
{
    object Instance { get; }
    IMetadataCollection MetadataCollection { get; }

    bool TryGetMetadataValue(string key, out object? value);
    bool TrySetMetadataValue(string key, object? value);
}
