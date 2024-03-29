﻿namespace Orc.Metadata.Tests.Models;

using System.Collections.Generic;
using Factories;
using NUnit.Framework;

[TestFixture]
public class DictionaryMetadataFacts
{
    private DictionaryMetadataCollection _metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();
    private Dictionary<string, object> _dictionary;

    [OneTimeSetUp]
    public void Init()
    {
        _metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();

        _dictionary = new Dictionary<string, object>();
        _dictionary["ExistingProperty"] = "works";
        _dictionary["StringProperty"] = null;
        _dictionary["IntProperty"] = 42;
    }

    [TestCase("ExistingProperty", "works")]
    [TestCase("StringProperty", null)]
    [TestCase("IntProperty", 42)]
    public void TheGetValueMethod(string metadataName, object expectedValue)
    {
        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TryGetValue(_dictionary, out object actualValue);

        Assert.That(result, Is.EqualTo(true));
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    [TestCase("ExistingProperty", "differentValue")]
    [TestCase("StringProperty", "stringvalue")]
    public void TheSetValueMethodString(string metadataName, string expectedValue)
    {
        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TrySetValue(_dictionary, expectedValue.ToString());

        Assert.That(result, Is.True);
        Assert.That(_dictionary[metadataName], Is.EqualTo(expectedValue));
    }

    [TestCase("IntProperty", 1)]
    public void TheSetValueMethodInt(string metadataName, int expectedValue)
    {
        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TrySetValue(_dictionary, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(_dictionary[metadataName], Is.EqualTo(expectedValue));
    }
}
