// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectWithMetadata.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public class ObjectWithMetadata : IObjectWithMetadata
    {
        public ObjectWithMetadata(object instance, IMetadataCollection metadataCollection)
        {
            Instance = instance;
            MetadataCollection = metadataCollection;
        }

        public object Instance { get; private set; }

        public IMetadataCollection MetadataCollection { get; private set; }

        public virtual object GetMetadataValue(string key)
        {
            return GetMetadataValueWithInstance(Instance, key);
        }

        public virtual bool SetMetadataValue(string key, object value)
        {
            return SetMetadataValueWithInstance(Instance, key, value);
        }

        protected object GetMetadataValueWithInstance(object instance, string key)
        {
            var metadata = MetadataCollection.GetMetadata(key);
            if (metadata is null)
            {
                return null;
            }

            if (!metadata.GetValue<object>(instance, out var value))
            {
                return null;
            }

            return value;
        }

        protected bool SetMetadataValueWithInstance(object instance, string key, object value)
        {
            var metadata = MetadataCollection.GetMetadata(key);
            if (metadata is null)
            {
                return false;
            }

            metadata.SetValue(instance, value);
            return true;
        }
    }
}
