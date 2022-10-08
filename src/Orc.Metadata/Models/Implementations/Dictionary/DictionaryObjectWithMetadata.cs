namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;

    public class DictionaryObjectWithMetadata : ObjectWithMetadata
    {
        private readonly Dictionary<string, object?> _metadata;

        public DictionaryObjectWithMetadata(object instance, Dictionary<string, Type> dictionarySchema, Dictionary<string, object?> metadata)
            : base(instance, new DictionaryMetadataCollection(dictionarySchema))
        {
            ArgumentNullException.ThrowIfNull(instance);
            ArgumentNullException.ThrowIfNull(dictionarySchema);
            ArgumentNullException.ThrowIfNull(metadata);

            _metadata = metadata;
        }

        public override bool TryGetMetadataValue(string key, out object? value)
        {
            return TryGetMetadataValueWithInstance(_metadata, key, out value);
        }

        public override bool TrySetMetadataValue(string key, object? value)
        {
            return TrySetMetadataValueWithInstance(_metadata, key, value);
        }
    }
}
