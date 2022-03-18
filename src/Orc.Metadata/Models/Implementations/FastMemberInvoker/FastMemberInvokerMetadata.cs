namespace Orc.Metadata
{
    using System;
    using Catel;
    using Catel.Reflection;

    public class FastMemberInvokerMetadata : IMetadata
    {
        private readonly IFastMemberInvoker _fastMemberInvoker;

        public FastMemberInvokerMetadata(IFastMemberInvoker fastMemberInvoker, string name, Type type)
        {
            Argument.IsNotNull(() => fastMemberInvoker);

            _fastMemberInvoker = fastMemberInvoker;
            Name = name;
            DisplayName = Name;
            Type = type;
        }

        public string Name { get; }

        public string DisplayName { get; set; }

        public Type Type { get; }

        public object GetValue(object instance)
        {
            object result = null;

            if (instance is not null)
            {
                _fastMemberInvoker.TryGetPropertyValue(instance, Name, out result);
            }

            return result;
        }

        public void SetValue(object instance, object value)
        {
            if (instance is null)
            {
                return;
            }

            _fastMemberInvoker.SetPropertyValue(instance, Name, value);
        }

        public bool GetValue<TValue>(object instance, out TValue value)
        {
            if (instance is null)
            {
                value = default;
                return false;
            }

            return _fastMemberInvoker.TryGetPropertyValue(instance, Name, out value);
        }

        public bool SetValue<TValue>(object instance, TValue value)
        {
            if (instance is null)
            {
                return false;
            }

            return _fastMemberInvoker.SetPropertyValue(instance, Name, value);
        }
    }
}
