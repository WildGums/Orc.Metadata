namespace Orc.Metadata.Tests
{
    using Catel.Reflection;
    using NUnit.Framework;
    using Orc.Metadata.Tests.Fixtures;

    [TestFixture]
    public class FastMemeberInvokerMetadataFacts
    {

        [TestCase("ExistingProperty", "works")]
        [TestCase("StringProperty", null)]
        [TestCase("IntProperty", 42)]
        public void TheGetValueMethod(string metadataName, object expectedValue)
        {
            var metadataCollection = new FastMemberInvokerMetadataCollection(new FastMemberInvoker<TestModel>(), typeof(TestModel));

            var model = new TestModel
            {
                ExistingProperty = "works",
                StringProperty = null,
                IntProperty = 42
            };

            var metadata = metadataCollection.GetMetadata(metadataName);
            var result = metadata.GetValue(model, out object actualValue);

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(result, true);
        }

        [TestCase("ExistingProperty", "differentValue")]
        [TestCase("StringProperty", "stringvalue")]

        public void TheSetValueMethodString(string metadataName, string expectedValue)
        {
            var metadataCollection = new FastMemberInvokerMetadataCollection(new FastMemberInvoker<TestModel>(), typeof(TestModel));

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

        [TestCase("IntProperty", 1)]
        public void TheSetValueMethodInt(string metadataName, int expectedValue)
        {
            var metadataCollection = new FastMemberInvokerMetadataCollection(new FastMemberInvoker<TestModel>(), typeof(TestModel));

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
