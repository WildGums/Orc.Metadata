// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadataCollectionFacts.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata.Tests
{
    using System.Linq;
    using Fixtures;
    using Models.Factories;
    using NUnit.Framework;

    [TestFixture]
    public class ReflectionMetadataCollectionFacts
    {
        [TestCase]
        public void TheAllProperty()
        {
            var metadataCollection = new ReflectionMetadataCollection(typeof (TestModel));

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
            var metadataCollection = new ReflectionMetadataCollection(typeof(TestModel));
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
}