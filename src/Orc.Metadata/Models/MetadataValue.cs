namespace Orc.Metadata;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Metadata.Name} => {ObjectValue}")]
public class MetadataValue : IMetadataValue
{
    public MetadataValue(IMetadata metadata)
    {
        ArgumentNullException.ThrowIfNull(metadata);

        Metadata = metadata;
    }

    public IMetadata Metadata { get; private set; }

    public virtual object? ObjectValue { get; set; }
}

[DebuggerDisplay("{Metadata.Name} => {Value}")]
public class MetadataValue<TValue> : MetadataValue, IMetadataValue<TValue>
{
    public MetadataValue(IMetadata metadata)
        : base(metadata)
    {
    }

    public TValue? Value { get; set; }

    public override object? ObjectValue
    {
        get => Value;
        set => Value = (TValue?)value;
    }
}
