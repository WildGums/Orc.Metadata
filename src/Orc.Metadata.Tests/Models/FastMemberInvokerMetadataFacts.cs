namespace Orc.Metadata.Tests
{
    using Catel.Reflection;
    using NUnit.Framework;
    using Orc.Metadata.Tests.Fixtures;

    [TestFixture]
    public class FastMemberInvokerMetadataFacts
    {
        private ReflectionMetadataCollection _metadataCollection;
        private TestModel _model;

        [OneTimeSetUp]
        public void Init()
        {
            _metadataCollection = new ReflectionMetadataCollection(typeof(TestModel));

            _model = new TestModel
            {
                ExistingProperty = "works",
                StringProperty = null,
                IntProperty = 42
            };

        }


        [TestCase("ExistingProperty", "works")]
        [TestCase("StringProperty", null)]
        [TestCase("IntProperty", 42)]
        public void TheGetValueMethod(string metadataName, object expectedValue)
        {
            var metadata = _metadataCollection.GetMetadata(metadataName);
            var result = metadata.GetValue(_model, out object actualValue);

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(result, true);
        }

        [TestCase("ExistingProperty", "differentValue")]
        [TestCase("StringProperty", "stringvalue")]

        public void TheSetValueMethodString(string metadataName, string expectedValue)
        {
            var metadata = _metadataCollection.GetMetadata(metadataName);
            metadata.SetValue(_model, expectedValue);

            Assert.AreEqual(expectedValue, PropertyHelper.GetPropertyValue(_model, metadataName, false));
        }

        [TestCase("IntProperty", 1)]
        public void TheSetValueMethodInt(string metadataName, int expectedValue)
        {
            var metadata = _metadataCollection.GetMetadata(metadataName);
            metadata.SetValue(_model, expectedValue);

            Assert.AreEqual(expectedValue, PropertyHelper.GetPropertyValue(_model, metadataName, false));

        }
    }
}
