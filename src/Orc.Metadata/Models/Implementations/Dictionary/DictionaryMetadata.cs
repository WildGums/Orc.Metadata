namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;
    using Catel;

    public class DictionaryMetadata : IMetadata
    {
        private readonly Type _expectedType;
        private readonly string _key;

        public DictionaryMetadata(string key, Type expectedType)
        {
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(expectedType);

            _key = key;
            DisplayName = key;
            _expectedType = expectedType;
        }

        public virtual string DisplayName { get; set; }

        public virtual string Name
        {
            get { return _key; }
        }

        public virtual Type Type
        {
            get { return _expectedType; }
        }

        public virtual bool TryGetValue(object instance, out object? value)
        {
            value = null;

            if (instance is IDictionary<string, object?> dictionary)
            {
                return dictionary.TryGetValue(_key, out value);
            }

            return false;
        }

        public bool TryGetValue<TValue>(object instance, out TValue? value)
        {
            if (instance is IDictionary<string, object?> dictionary 
                && dictionary.TryGetValue(_key, out var result))
            {
                if (ObjectHelper.AreEqual(result, default(TValue)))
                {
                    value = default;
                    return true;
                }

                if (result is TValue resultValue)
                {
                    value = resultValue;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public virtual bool TrySetValue(object instance, object? value)
        {
            if (instance is IDictionary<string, object?> dictionary)
            {
                dictionary[_key] = value;
                return true;
            }

            return false;
        }

        public bool TrySetValue<TValue>(object instance, TValue? value)
        {
            if (instance is IDictionary<string, object?> dictionary)
            {
                dictionary[_key] = value;
                return true;
            }

            return false;
        }
    }
}
