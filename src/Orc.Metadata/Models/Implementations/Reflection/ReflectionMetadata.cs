namespace Orc.Metadata;

using System;
using System.Reflection;
using Catel;
using Catel.Reflection;

public class ReflectionMetadata : IMetadata
{
    private readonly PropertyInfo _propertyInfo;

    public ReflectionMetadata(PropertyInfo propertyInfo)
    {
        ArgumentNullException.ThrowIfNull(propertyInfo);

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

    public virtual bool TryGetValue(object instance, out object? value)
    {
        ArgumentNullException.ThrowIfNull(instance);

        value = _propertyInfo.GetValue(instance, null);
        return true;
    }

    public bool TryGetValue<TValue>(object instance, out TValue? value)
    {
        ArgumentNullException.ThrowIfNull(instance);

        if (!_propertyInfo.DeclaringType?.IsAssignableFromEx(instance.GetType()) ?? false)
        {
            value = default;
            return false;
        }

        if (!TryGetValue(instance, out object? objectValue))
        {
            value = default;
            return false;
        }

        if (ObjectHelper.AreEqual(objectValue, default(TValue)))
        {
            value = default;
            return true;
        }

        if (objectValue is TValue propertyValue)
        {
            value = propertyValue;
            return true;
        }

        value = default;
        return false;
    }

    public virtual bool TrySetValue(object instance, object? value)
    {
        _propertyInfo.SetValue(instance, value, null);
        return true;
    }

    public bool TrySetValue<TValue>(object instance, TValue value)
    {
        if (!Type.IsAssignableFromEx(typeof(TValue)) || (!_propertyInfo.DeclaringType?.IsAssignableFromEx(instance.GetType()) ?? false))
        {
            return false;
        }

        _propertyInfo.SetValue(instance, value, null);

        return true;
    }
}
