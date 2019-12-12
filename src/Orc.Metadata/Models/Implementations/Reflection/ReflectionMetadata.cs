// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionMetadata.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;
    using System.Reflection;
    using Catel;
    using Catel.Reflection;

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

        public virtual string Name { get; private set; }

        public virtual string DisplayName { get; set; }

        public virtual Type Type
        {
            get { return _propertyInfo.PropertyType; }
        }

        public virtual object GetValue(object instance)
        {
            return _propertyInfo.GetValue(instance, null);
        }

        public bool GetValue<TValue>(object instance, out TValue value)
        {
            if (instance is null || !_propertyInfo.DeclaringType.IsAssignableFrom(instance.GetType()))
            {
                value = default;
                return false;
            }

            var result = GetValue(instance);

            if(Equals(result, default(TValue)))
            {
                value = default;
                return true;
            }

            if (GetValue(instance) is TValue propertyValue)
            {
                value = propertyValue;
                return true;
            }

            value = default;
            return false;
        }

        public virtual void SetValue(object instance, object value)
        {
            _propertyInfo.SetValue(instance, value, null);
        }

        public bool SetValue<TValue>(object instance, TValue value)
        {
            if (instance is null || !Type.IsAssignableFrom(typeof(TValue)) || !_propertyInfo.DeclaringType.IsAssignableFrom(instance.GetType()))
            {
                return false;
            }

            _propertyInfo.SetValue(instance, value, null);

            return false;
        }
    }
}
