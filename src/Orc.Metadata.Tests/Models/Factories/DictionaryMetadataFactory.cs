namespace Orc.Metadata.Tests.Models.Factories;

using System;
using System.Collections.Generic;
using System.Windows.Media;

public static class DictionaryMetadataFactory
{
    public static Dictionary<string, Type> CreateSchemaDictionary()
    {
        var dictionary = new Dictionary<string, Type>
        {
            ["StringProperty"] = typeof(string),
            ["IntProperty"] = typeof(int),
            ["ExistingProperty"] = typeof(string)
        };

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

        var metadata = new Dictionary<string, object>
        {
            ["ExistingProperty"] = "works",
            ["StringProperty"] = null,
            ["IntProperty"] = 42
        };

        var objectWithMetadata = new DictionaryObjectWithMetadata(metadata, schema, metadata);
        return objectWithMetadata;

    }

    public static IObjectWithMetadata CreateHierarchicalObjectWithMetadata()
    {
        var solidColorBrush = Brushes.Red;
        var color = solidColorBrush.Color;

        var metadataSchema = new Dictionary<string, Type>
        {
            ["Name"] = typeof(string),
            ["RGB"] = typeof(string),
            ["Color"] = typeof(IObjectWithMetadata)
        };

        var colorMetadataSchema = new Dictionary<string, Type>
        {
            ["A"] = typeof(int),
            ["R"] = typeof(int),
            ["G"] = typeof(int),
            ["B"] = typeof(int)
        };

        var colorMetadata = new Dictionary<string, object>
        {
            ["A"] = color.A,
            ["R"] = color.R,
            ["G"] = color.G,
            ["B"] = color.B
        };

        var colorObjectWithMetadata = new DictionaryObjectWithMetadata(solidColorBrush, colorMetadataSchema, colorMetadata);

        var metadata = new Dictionary<string, object>
        {
            ["Name"] = solidColorBrush.ToString(),
            ["RGB"] = solidColorBrush.ToString(),
            ["Color"] = colorObjectWithMetadata
        };

        return new DictionaryObjectWithMetadata(solidColorBrush, metadataSchema, metadata);
    }
}
