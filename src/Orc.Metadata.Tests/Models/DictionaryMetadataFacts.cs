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

    [TestFixture]
    public class DictionaryMetadataFacts
    {
        private DictionaryMetadataCollection _metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();
        private Dictionary<string, object> _dictionary;

        [OneTimeSetUp]
        public void Init()
        {
            _metadataCollection = DictionaryMetadataFactory.CreateMetadataCollection();

            _dictionary = new Dictionary<string, object>();
            _dictionary["ExistingProperty"] = "works";
            _dictionary["StringProperty"] = null;
            _dictionary["IntProperty"] = 42;
        }

        [TestCase("ExistingProperty", "works")]
        [TestCase("StringProperty", null)]
        [TestCase("IntProperty", 42)]
        public void TheGetValueMethod(string metadataName, object expectedValue)
        {
            var metadata = _metadataCollection.GetMetadata(metadataName);
            var result = metadata.GetValue(_dictionary, out object actualValue);

            Assert.AreEqual(result, true);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("ExistingProperty", "differentValue")]
        [TestCase("StringProperty", "stringvalue")]
        public void TheSetValueMethodString(string metadataName, string expectedValue)
        {
            var metadata = _metadataCollection.GetMetadata(metadataName);
            metadata.SetValue(_dictionary, expectedValue.ToString());

            Assert.AreEqual(expectedValue, _dictionary[metadataName]);
        }

        [TestCase("IntProperty", 1)]
        public void TheSetValueMethodInt(string metadataName, int expectedValue)
        {
            var metadata = _metadataCollection.GetMetadata(metadataName);
            metadata.SetValue(_dictionary, expectedValue);

            Assert.AreEqual(expectedValue, _dictionary[metadataName]);
        }
    }
}
