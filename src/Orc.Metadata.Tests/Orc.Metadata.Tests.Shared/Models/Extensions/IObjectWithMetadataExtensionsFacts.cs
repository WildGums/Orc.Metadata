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
        public class TheConvertToStaticMetadataMethod
        {
            [TestCase]
            public void ConvertsFlatMetadataCollectionToList()
            {
                var objectWithMetadata = DictionaryMetadataFactory.CreateFlatObjectWithMetadata();

                var flatList = objectWithMetadata.ToStaticMetadata();

                Assert.AreEqual(3, flatList.Count);
                Assert.AreEqual(null, flatList[0].Value);
                Assert.AreEqual(42, flatList[1].Value);
                Assert.AreEqual("works", flatList[2].Value);
            }

            //[TestCase]
            //public void ConvertsHierarchicalMetadataCollectionToList()
            //{

            //}
        }
    }
}