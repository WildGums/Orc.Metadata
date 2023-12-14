namespace Orc.Metadata.Tests.Models;

using System.Linq;
using Catel.Reflection;
using NUnit.Framework;
using Fixtures;

[TestFixture]
public class FastMemberInvokerMetadataCollectionFacts
{
    [TestCase]
    public void TheAllProperty()
    {
        var metadataCollection = new FastMemberInvokerMetadataCollection(new FastMemberInvoker<TestModel>(),typeof(TestModel));

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
        var metadataCollection = new FastMemberInvokerMetadataCollection(new FastMemberInvoker<TestModel>(), typeof(TestModel));
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
