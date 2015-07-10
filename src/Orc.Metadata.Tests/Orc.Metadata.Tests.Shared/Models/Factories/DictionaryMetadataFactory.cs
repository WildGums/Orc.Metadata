// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadataFactory.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata.Tests.Models.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

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

        public static IObjectWithMetadata CreateHierarchicalObjectWithMetadata()
        {
            var solidColorBrush = Brushes.Red;
            var color = solidColorBrush.Color;

            var metadataSchema = new Dictionary<string, Type>();
            metadataSchema["Name"] = typeof(string);
            metadataSchema["RGB"] = typeof(string);
            metadataSchema["Color"] = typeof(IObjectWithMetadata);

            var colorMetadataSchema = new Dictionary<string, Type>();
            colorMetadataSchema["A"] = typeof(int);
            colorMetadataSchema["R"] = typeof(int);
            colorMetadataSchema["G"] = typeof(int);
            colorMetadataSchema["B"] = typeof(int);

            var colorMetadata = new Dictionary<string, object>();
            colorMetadata["A"] = color.A;
            colorMetadata["R"] = color.R;
            colorMetadata["G"] = color.G;
            colorMetadata["B"] = color.B;

            var colorObjectWithMetadata = new DictionaryObjectWithMetadata(solidColorBrush, colorMetadataSchema, colorMetadata);

            var metadata = new Dictionary<string, object>();
            metadata["Name"] = solidColorBrush.ToString();
            metadata["RGB"] = solidColorBrush.ToString();
            metadata["Color"] = colorObjectWithMetadata;

            return new DictionaryObjectWithMetadata(solidColorBrush, metadataSchema, metadata);
        }
    }
}