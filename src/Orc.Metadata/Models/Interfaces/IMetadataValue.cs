namespace Orc.Metadata
{
    public interface IMetadataValue
    {
        IMetadata Metadata { get; }
        object? ObjectValue { get; set; }
    }

    public interface IMetadataValue<TValue> : IMetadataValue
    {
        TValue? Value { get; set; }
    }
}
