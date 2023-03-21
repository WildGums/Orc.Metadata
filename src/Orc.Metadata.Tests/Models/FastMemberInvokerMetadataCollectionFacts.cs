namespace Orc.Metadata.Tests.Models;

using System.Linq;
using Catel.Reflection;
using NUnit.Framework;
using Orc.Metadata.Tests.Fixtures;

[TestFixture]
public class FastMemberInvokerMetadataCollectionFacts
{
    [TestCase]
    public void TheAllProperty()
    {
        var metadataCollection = new FastMemberInvokerMetadataCollection(new FastMemberInvoker<TestModel>(),typeof(TestModel));

        var all = metadataCollection.All.ToList();

        Assert.AreEqual(3, all.Count);
        Assert.AreEqual("StringProperty", all[0].Name);
        Assert.AreEqual("IntProperty", all[1].Name);
        Assert.AreEqual("ExistingProperty", all[2].Name);
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
            Assert.IsNotNull(metadata);
        }
        else
        {
            Assert.IsNull(metadata);
        }
    }
}
