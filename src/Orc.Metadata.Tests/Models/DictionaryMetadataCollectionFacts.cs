namespace Orc.Metadata.Tests;

using System.Linq;
using Models.Factories;
using NUnit.Framework;

[TestFixture]
public class DictionaryMetadataCollectionFacts
{
    [TestCase]
    public void TheAllProperty()
    {
        var metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();

        var all = metadataCollection.All.ToList();

        Assert.That(all.Count, Is.EqualTo(3));
        Assert.That(all[0].Name, Is.EqualTo("StringProperty"));
        Assert.That(all[1].Name, Is.EqualTo("IntProperty"));
        Assert.That(all[2].Name, Is.EqualTo("ExistingProperty"));
    }

    [TestCase("ExistingProperty", true)]
    [TestCase("StringProperty", true)]
    [TestCase("IntProperty", true)]
    [TestCase("NotExistingValue", false)]
    public void TheGetMetadataMethod(string metadataName, bool shouldExist)
    {
        var metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();
        var metadata = metadataCollection.GetMetadata(metadataName);

        if (shouldExist)
        {
            Assert.That(metadata, Is.Not.Null);
        }
        else
        {
            Assert.That(metadata, Is.Null);
        }
    }
}
