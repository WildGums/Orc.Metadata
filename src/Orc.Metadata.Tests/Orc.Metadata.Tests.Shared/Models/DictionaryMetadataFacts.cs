// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadataFacts.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata.Tests.Models
{
    using System.Collections.Generic;
    using Factories;
    using NUnit.Framework;

    public class DictionaryMetadataFacts
    {
        [TestCase("ExistingProperty", "works")]
        [TestCase("StringProperty", null)]
        [TestCase("IntProperty", 42)]
        public void TheGetValueMethod(string metadataName, object expectedValue)
        {
            var metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();

            var dictionary = new Dictionary<string, object>();
            dictionary["ExistingProperty"] = "works";
            dictionary["StringProperty"] = null;
            dictionary["IntProperty"] = 42;

            var metadata = metadataCollection.GetMetadata(metadataName);
            var actualValue = metadata.GetValue(dictionary);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("ExistingProperty", "differentValue")]
        [TestCase("StringProperty", "stringvalue")]
        [TestCase("IntProperty", 1)]
        public void TheSetValueMethod(string metadataName, object expectedValue)
        {
            var metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();

            var dictionary = new Dictionary<string, object>();
            dictionary["ExistingProperty"] = "works";
            dictionary["StringProperty"] = null;
            dictionary["IntProperty"] = 42;

            var metadata = metadataCollection.GetMetadata(metadataName);
            metadata.SetValue(dictionary, expectedValue);

            Assert.AreEqual(expectedValue, dictionary[metadataName]);
        }
    }
}