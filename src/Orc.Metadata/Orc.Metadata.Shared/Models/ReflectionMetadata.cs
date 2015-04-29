// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionMetadata.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;
    using System.Reflection;
    using Catel;

    public class ReflectionMetadata : IMetadata
    {
        private readonly PropertyInfo _propertyInfo;

        public ReflectionMetadata(PropertyInfo propertyInfo)
        {
            Argument.IsNotNull(() => propertyInfo);

            _propertyInfo = propertyInfo;

            Name = _propertyInfo.Name;
            DisplayName = Name;
        }

        public string Name { get; private set; }

        public string DisplayName { get; set; }

        public object GetValue(object instance)
        {
            return _propertyInfo.GetValue(instance, null);
        }

        public void SetValue(object instance, object value)
        {
            _propertyInfo.SetValue(instance, value, null);
        }

        public Type Type
        {
            get { return _propertyInfo.PropertyType; }
        }
    }
}