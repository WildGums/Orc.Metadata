// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadata.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;
    using System.Collections.Generic;
    using Catel;

    public class DictionaryMetadata : IMetadata
    {
        #region Fields
        private readonly Type _expectedType;
        private readonly string _key;
        #endregion

        #region Constructors
        public DictionaryMetadata()
        {
        }

        public DictionaryMetadata(string key, Type expectedType)
            : this()
        {
            Argument.IsNotNull(() => key);
            Argument.IsNotNull(() => expectedType);

            _key = key;
            DisplayName = key;
            _expectedType = expectedType;
        }
        #endregion

        #region Properties
        public string DisplayName { get; set; }

        public string Name
        {
            get { return _key; }
        }

        public Type Type
        {
            get { return _expectedType; }
        }
        #endregion

        #region Methods
        public object GetValue(object instance)
        {
            //Argument.IsOfType(() => instance, typeof(IDictionary<string, object>));

            object result = null;

            var dictionary = instance as IDictionary<string, object>;
            if (dictionary != null)
            {
                dictionary.TryGetValue(_key, out result);
            }

            return result;
        }

        public void SetValue(object instance, object value)
        {
            //Argument.IsOfType(() => instance, typeof(IDictionary<string, object>));

            var dictionary = instance as IDictionary<string, object>;
            if (dictionary == null)
            {
                return;
            }

            dictionary[_key] = value;
        }
        #endregion
    }
}