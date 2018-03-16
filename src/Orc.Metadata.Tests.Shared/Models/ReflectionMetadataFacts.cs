// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadataFacts.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata.Tests.Models
{
    using Catel.Reflection;
    using Fixtures;
    using NUnit.Framework;

    public class ReflectionMetadataFacts
    {
        [TestCase("ExistingProperty", "works")]
        [TestCase("StringProperty", null)]
        [TestCase("IntProperty", 42)]
        public void TheGetValueMethod(string metadataName, object expectedValue)
        {
            var metadataCollection = new ReflectionMetadataCollection(typeof (TestModel));

            var model = new TestModel
            {
                ExistingProperty = "works",
                StringProperty = null,
                IntProperty = 42
            };
   
            var metadata = metadataCollection.GetMetadata(metadataName);
            var actualValue = metadata.GetValue(model);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("ExistingProperty", "differentValue")]
        [TestCase("StringProperty", "stringvalue")]
        [TestCase("IntProperty", 1)]
        public void TheSetValueMethod(string metadataName, object expectedValue)
        {
            var metadataCollection = new ReflectionMetadataCollection(typeof(TestModel));

            var model = new TestModel
            {
                ExistingProperty = "works",
                StringProperty = null,
                IntProperty = 42
            };

            var metadata = metadataCollection.GetMetadata(metadataName);
            metadata.SetValue(model, expectedValue);

            Assert.AreEqual(expectedValue, PropertyHelper.GetPropertyValue(model, metadataName, false));
        }
    }
}