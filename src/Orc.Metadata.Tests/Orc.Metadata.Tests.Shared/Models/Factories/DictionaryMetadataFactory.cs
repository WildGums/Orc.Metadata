// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadataFactory.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata.Tests.Models.Factories
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryMetadataFactory
    {
        public static DictionaryMetadataCollection CreateDictionary()
        {
            var dictionary = new Dictionary<string, Type>();

            dictionary["StringProperty"] = typeof(string);
            dictionary["IntProperty"] = typeof(int);
            dictionary["ExistingProperty"] = typeof(string);

            return new DictionaryMetadataCollection(dictionary);
        }
    }
}