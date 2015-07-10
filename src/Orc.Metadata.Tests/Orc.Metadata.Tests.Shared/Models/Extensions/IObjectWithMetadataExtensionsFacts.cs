// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectWithMetadataExtensionsFacts.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata.Tests.Models
{
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
                Assert.AreEqual(null, dictionary["StringProperty"].Value);
                Assert.AreEqual(42, dictionary["IntProperty"].Value);
                Assert.AreEqual("works", dictionary["ExistingProperty"].Value);
            }

            [TestCase]
            public void ConvertsHierarchicalMetadataCollectionToList()
            {
                var objectWithMetadata = DictionaryMetadataFactory.CreateHierarchicalObjectWithMetadata();

                var dictionary = objectWithMetadata.ToStaticMetadataDictionary();

                Assert.AreEqual(3, dictionary.Count);

                Assert.AreEqual("#FFFF0000", dictionary["Name"].Value);
                Assert.AreEqual("#FFFF0000", dictionary["RGB"].Value);

                var subDictionary = (Dictionary<string, IMetadataValue>)dictionary["Color"].Value;
                Assert.AreEqual(4, subDictionary.Count);
                Assert.AreEqual(255, subDictionary["A"].Value);
                Assert.AreEqual(255, subDictionary["R"].Value);
                Assert.AreEqual(0, subDictionary["G"].Value);
                Assert.AreEqual(0, subDictionary["B"].Value);
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
                Assert.AreEqual(null, flatList[0].Value);
                Assert.AreEqual(42, flatList[1].Value);
                Assert.AreEqual("works", flatList[2].Value);
            }
        }
    }
}