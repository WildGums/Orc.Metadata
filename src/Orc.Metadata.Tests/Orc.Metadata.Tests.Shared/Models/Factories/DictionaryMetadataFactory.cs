// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadataFactory.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata.Tests.Models.Factories
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryMetadataFactory
    {
        public static Dictionary<string, Type> CreateSchemaDictionary()
        {
            var dictionary = new Dictionary<string, Type>();

            dictionary["StringProperty"] = typeof(string);
            dictionary["IntProperty"] = typeof(int);
            dictionary["ExistingProperty"] = typeof(string);

            return dictionary;
        }

        public static DictionaryMetadataCollection CreateMetadataCollection()
        {
            var schema = CreateSchemaDictionary();

            return new DictionaryMetadataCollection(schema);
        }

        public static IObjectWithMetadata CreateFlatObjectWithMetadata()
        {
            var schema = CreateSchemaDictionary();

            var metadata = new Dictionary<string, object>();
            metadata["ExistingProperty"] = "works";
            metadata["StringProperty"] = null;
            metadata["IntProperty"] = 42;

            var objectWithMetadata = new DictionaryObjectWithMetadata(metadata, schema, metadata);
            return objectWithMetadata;

        }

        //public static IObjectWithMetadata CreateHierarchicalObjectWithMetadata()
        //{

        //}
    }
}