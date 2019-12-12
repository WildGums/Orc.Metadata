// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMetadata.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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
        public virtual string DisplayName { get; set; }

        public virtual string Name
        {
            get { return _key; }
        }

        public virtual Type Type
        {
            get { return _expectedType; }
        }
        #endregion

        #region Methods
        public virtual object GetValue(object instance)
        {
            object result = null;

            if(instance is IDictionary<string, object> dictionary)
            {
                dictionary.TryGetValue(_key, out result);
            }

            return result;
        }

        public bool GetValue<TValue>(object instance, out TValue value)
        {
            if(instance is IDictionary<string, TValue> dictionary)
            {
                dictionary.TryGetValue(_key, out value);

                return true;
            }

            value = default;
            return false;
        }

        public virtual void SetValue(object instance, object value)
        {
            if(instance is IDictionary<string, object> dictionary)
            {
                dictionary[_key] = value;
            }
        }

        public bool SetValue<TValue>(object instance, TValue value)
        {
            if(instance is IDictionary<string,TValue> dictionary)
            {
                dictionary[_key] = value;
                return true;
            }

            return false;
        }
        #endregion
    }
}
