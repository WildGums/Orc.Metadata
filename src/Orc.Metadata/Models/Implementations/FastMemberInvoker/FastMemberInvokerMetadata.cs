namespace Orc.Metadata;

using System;
using Catel.Reflection;

public class FastMemberInvokerMetadata : IMetadata
{
    private readonly IFastMemberInvoker _fastMemberInvoker;

    public FastMemberInvokerMetadata(IFastMemberInvoker fastMemberInvoker, string name, Type type)
    {
        ArgumentNullException.ThrowIfNull(fastMemberInvoker);

        _fastMemberInvoker = fastMemberInvoker;
        Name = name;
        DisplayName = Name;
        Type = type;
    }

    public string Name { get; }

    public string DisplayName { get; set; }

    public Type Type { get; }

    public bool TryGetValue(object instance, out object? value)
    {
        ArgumentNullException.ThrowIfNull(instance);

        return _fastMemberInvoker.TryGetPropertyValue(instance, Name, out value);
    }

    public bool TrySetValue(object instance, object value)
    {
        ArgumentNullException.ThrowIfNull(instance);

        return _fastMemberInvoker.TrySetPropertyValue(instance, Name, value);
    }

    public bool TryGetValue<TValue>(object instance, out TValue value)
    {
        ArgumentNullException.ThrowIfNull(instance);

        return _fastMemberInvoker.TryGetPropertyValue(instance, Name, out value);
    }

    public bool TrySetValue<TValue>(object instance, TValue value)
    {
        ArgumentNullException.ThrowIfNull(instance);

        return _fastMemberInvoker.TrySetPropertyValue(instance, Name, value);
    }
}
