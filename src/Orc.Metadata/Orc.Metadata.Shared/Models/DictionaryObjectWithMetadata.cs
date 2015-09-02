// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryObjectWithMetadata.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;

    public class DictionaryObjectWithMetadata : ObjectWithMetadata
    {
        private readonly Dictionary<string, object> _metadata;

        #region Constructors
        public DictionaryObjectWithMetadata(object instance, Dictionary<string, Type> dictionarySchema, Dictionary<string, object> metadata)
            : base(instance, new DictionaryMetadataCollection(dictionarySchema))
        {
            _metadata = metadata;
        }
        #endregion

        public override object GetMetadataValue(string key)
        {
            return GetMetadataValueWithInstance(_metadata, key);
        }

        public override bool SetMetadataValue(string key, object value)
        {
            return SetMetadataValueWithInstance(_metadata, key, value);
        }
    }
}