namespace Orc.Metadata.Tests.Models;

using Catel.Reflection;
using Fixtures;
using NUnit.Framework;

[TestFixture]
public class ReflectionMetadataFacts
{
    private ReflectionMetadataCollection _metadataCollection;
    private TestModel _model;

    [OneTimeSetUp]
    public void Init()
    {
        _metadataCollection = new ReflectionMetadataCollection(typeof(TestModel));

        _model = new TestModel
        {
            ExistingProperty = "works",
            StringProperty = null,
            IntProperty = 42
        };
    }

    [TestCase("ExistingProperty", "works")]
    [TestCase("StringProperty", null)]
    [TestCase("IntProperty", 42)]
    public void TheGetValueMethod(string metadataName, object expectedValue)
    { 
        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TryGetValue(_model, out object actualValue);

        Assert.That(actualValue, Is.EqualTo(expectedValue));
        Assert.That(result, Is.True);
    }

    [TestCase("ExistingProperty", "differentValue")]
    [TestCase("StringProperty", "stringvalue")]

    public void TheSetValueMethodString(string metadataName, string expectedValue)
    {
        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TrySetValue(_model, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(PropertyHelper.GetPropertyValue(_model, metadataName), Is.EqualTo(expectedValue));
    }

    [TestCase("IntProperty", 1)]
    public void TheSetValueMethodInt(string metadataName, int expectedValue)
    {
        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TrySetValue(_model, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(PropertyHelper.GetPropertyValue(_model, metadataName), Is.EqualTo(expectedValue));
    }
}
