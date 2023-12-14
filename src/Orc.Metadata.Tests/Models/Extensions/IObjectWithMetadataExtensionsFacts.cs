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

            Assert.That(dictionary.Count, Is.EqualTo(3));
            Assert.That(dictionary["StringProperty"].ObjectValue, Is.EqualTo(null));
            Assert.That(dictionary["IntProperty"].ObjectValue, Is.EqualTo(42));
            Assert.That(dictionary["ExistingProperty"].ObjectValue, Is.EqualTo("works"));
        }

        [TestCase]
        public void ConvertsHierarchicalMetadataCollectionToList()
        {
            var objectWithMetadata = DictionaryMetadataFactory.CreateHierarchicalObjectWithMetadata();

            var dictionary = objectWithMetadata.ToStaticMetadataDictionary();

            Assert.That(dictionary.Count, Is.EqualTo(3));

            Assert.That(dictionary["Name"].ObjectValue, Is.EqualTo("#FFFF0000"));
            Assert.That(dictionary["RGB"].ObjectValue, Is.EqualTo("#FFFF0000"));

            var subDictionary = (Dictionary<string, IMetadataValue>)dictionary["Color"].ObjectValue;
            Assert.That(subDictionary.Count, Is.EqualTo(4));
            Assert.That(subDictionary["A"].ObjectValue, Is.EqualTo(255));
            Assert.That(subDictionary["R"].ObjectValue, Is.EqualTo(255));
            Assert.That(subDictionary["G"].ObjectValue, Is.EqualTo(0));
            Assert.That(subDictionary["B"].ObjectValue, Is.EqualTo(0));
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

            Assert.That(flatList.Count, Is.EqualTo(3));
            Assert.That(flatList[0].ObjectValue, Is.EqualTo(null));
            Assert.That(flatList[1].ObjectValue, Is.EqualTo(42));
            Assert.That(flatList[2].ObjectValue, Is.EqualTo("works"));
        }
    }
}
