namespace Orc.Metadata.Tests.Models;

using System.Collections.Generic;
using Factories;
using NUnit.Framework;

public class IObjectWithMetadataExtensionsFacts
{
    [TestFixture]
    public class TheConvertToStaticDictionaryMetadataMethod
    {
        [TestCase]
        public void ConvertsFlatMetadataCollectionToList()
        {
            var objectWithMetadata = DictionaryMetadataFactory.CreateFlatObjectWithMetadata();

            var dictionary = objectWithMetadata.ToStaticMetadataDictionary();

            Assert.AreEqual(3, dictionary.Count);
            Assert.AreEqual(null, dictionary["StringProperty"].ObjectValue);
            Assert.AreEqual(42, dictionary["IntProperty"].ObjectValue);
            Assert.AreEqual("works", dictionary["ExistingProperty"].ObjectValue);
        }

        [TestCase]
        public void ConvertsHierarchicalMetadataCollectionToList()
        {
            var objectWithMetadata = DictionaryMetadataFactory.CreateHierarchicalObjectWithMetadata();

            var dictionary = objectWithMetadata.ToStaticMetadataDictionary();

            Assert.AreEqual(3, dictionary.Count);

            Assert.AreEqual("#FFFF0000", dictionary["Name"].ObjectValue);
            Assert.AreEqual("#FFFF0000", dictionary["RGB"].ObjectValue);

            var subDictionary = (Dictionary<string, IMetadataValue>)dictionary["Color"].ObjectValue;
            Assert.AreEqual(4, subDictionary.Count);
            Assert.AreEqual(255, subDictionary["A"].ObjectValue);
            Assert.AreEqual(255, subDictionary["R"].ObjectValue);
            Assert.AreEqual(0, subDictionary["G"].ObjectValue);
            Assert.AreEqual(0, subDictionary["B"].ObjectValue);
        }
    }

    [TestFixture]
    public class TheConvertToStaticListMetadataMethod
    {
        [TestCase]
        public void ConvertsFlatMetadataCollectionToList()
        {
            var objectWithMetadata = DictionaryMetadataFactory.CreateFlatObjectWithMetadata();

            var flatList = objectWithMetadata.ToStaticMetadataList();

            Assert.AreEqual(3, flatList.Count);
            Assert.AreEqual(null, flatList[0].ObjectValue);
            Assert.AreEqual(42, flatList[1].ObjectValue);
            Assert.AreEqual("works", flatList[2].ObjectValue);
        }
    }
}
