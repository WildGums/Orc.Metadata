// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadataCollection.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Catel;

    public class DictionaryMetadataCollection : MetadataCollectionBase
    {
        private readonly List<IMetadata> _metadata;

        public DictionaryMetadataCollection()
        {
            _metadata = new List<IMetadata>();
        }

        public DictionaryMetadataCollection(Dictionary<string, Type> dictionarySchema)
            : this()
        {
            Argument.IsNotNull(() => dictionarySchema);

            _metadata = dictionarySchema.Select(kvp => new DictionaryMetadata(kvp.Key, kvp.Value)).Cast<IMetadata>().ToList();
        }

        public override IEnumerable<IMetadata> All
        {
            get { return _metadata; }
        }
    }
}