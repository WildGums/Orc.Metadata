namespace Orc.Metadata.Tests;

using Catel.Reflection;
using NUnit.Framework;
using Fixtures;

[TestFixture]
public class FastMemberInvokerMetadataFacts
{
    private ReflectionMetadataCollection _metadataCollection;

    [OneTimeSetUp]
    public void Init()
    {
        _metadataCollection = new ReflectionMetadataCollection(typeof(TestModel));
    }

    [TestCase("ExistingProperty", "works")]
    [TestCase("StringProperty", null)]
    [TestCase("IntProperty", 42)]
    public void TheTryGetValueMethod(string metadataName, object expectedValue)
    {
        var model = new TestModel
        {
            ExistingProperty = "works",
            StringProperty = null,
            IntProperty = 42
        };

        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TryGetValue(model, out object actualValue);

        Assert.That(result, Is.True);
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    [TestCase("ExistingProperty", "differentValue")]
    [TestCase("StringProperty", "stringvalue")]

    public void TheSetValueMethodString(string metadataName, string expectedValue)
    {
        var model = new TestModel
        {
            ExistingProperty = "works",
            StringProperty = null,
            IntProperty = 42
        };

        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TrySetValue(model, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(PropertyHelper.GetPropertyValue(model, metadataName, false), Is.EqualTo(expectedValue));
    }

    [TestCase("IntProperty", 1)]
    public void TheSetValueMethodInt(string metadataName, int expectedValue)
    {
        var model = new TestModel
        {
            ExistingProperty = "works",
            StringProperty = null,
            IntProperty = 42
        };

        var metadata = _metadataCollection.GetMetadata(metadataName);
        var result = metadata.TrySetValue(model, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(PropertyHelper.GetPropertyValue(model, metadataName, false), Is.EqualTo(expectedValue));
    }
}
