[assembly: System.Resources.NeutralResourcesLanguage("en-US")]
[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v5.0", FrameworkDisplayName="")]
public static class ModuleInitializer
{
    public static void Initialize() { }
}
namespace Orc.Metadata
{
    public class DictionaryMetadata : Orc.Metadata.IMetadata
    {
        public DictionaryMetadata() { }
        public DictionaryMetadata(string key, System.Type expectedType) { }
        public virtual string Name { get; }
        public virtual System.Type Type { get; }
        public virtual string DisplayName { get; set; }
        public virtual object GetValue(object instance) { }
        public bool GetValue<TValue>(object instance, out TValue value) { }
        public virtual void SetValue(object instance, object value) { }
        public bool SetValue<TValue>(object instance, TValue value) { }
    }
    public class DictionaryMetadataCollection : Orc.Metadata.MetadataCollectionBase
    {
        public DictionaryMetadataCollection() { }
        public DictionaryMetadataCollection(System.Collections.Generic.Dictionary<string, System.Type> dictionarySchema) { }
        public override System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata> All { get; }
    }
    public class DictionaryObjectWithMetadata : Orc.Metadata.ObjectWithMetadata
    {
        public DictionaryObjectWithMetadata(object instance, System.Collections.Generic.Dictionary<string, System.Type> dictionarySchema, System.Collections.Generic.Dictionary<string, object> metadata) { }
        public override object GetMetadataValue(string key) { }
        public override bool SetMetadataValue(string key, object value) { }
    }
    public class FastMemberInvokerMetadata : Orc.Metadata.IMetadata
    {
        public FastMemberInvokerMetadata(Catel.Reflection.IFastMemberInvoker fastMemberInvoker, string name, System.Type type) { }
        public string DisplayName { get; set; }
        public string Name { get; }
        public System.Type Type { get; }
        public object GetValue(object instance) { }
        public bool GetValue<TValue>(object instance, out TValue value) { }
        public void SetValue(object instance, object value) { }
        public bool SetValue<TValue>(object instance, TValue value) { }
    }
    public class FastMemberInvokerMetadataCollection : Orc.Metadata.MetadataCollectionBase
    {
        public FastMemberInvokerMetadataCollection(Catel.Reflection.IFastMemberInvoker memberInvoker, System.Type type) { }
        public override System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata> All { get; }
    }
    public class FastMemberInvokerMetadataProvider : Orc.Metadata.IMetadataProvider
    {
        public FastMemberInvokerMetadataProvider() { }
        public System.Threading.Tasks.Task<Orc.Metadata.IObjectWithMetadata> GetMetadataAsync(object obj) { }
    }
    public class FastMemberInvokerObjectWithMetadata : Orc.Metadata.ObjectWithMetadata
    {
        public FastMemberInvokerObjectWithMetadata(object instance, Catel.Reflection.IFastMemberInvoker memberInvoker) { }
    }
    public interface IMetadata
    {
        string DisplayName { get; set; }
        string Name { get; }
        System.Type Type { get; }
        bool GetValue<TValue>(object instance, out TValue value);
        bool SetValue<TValue>(object instance, TValue value);
    }
    public interface IMetadataCollection : System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata>, System.Collections.IEnumerable
    {
        System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata> All { get; }
        Orc.Metadata.IMetadata GetMetadata(string propertyName);
    }
    public static class IMetadataExtensions
    {
        public static bool GetValue<TValue>(this Orc.Metadata.IMetadata metadata, object instance, out TValue value, TValue defaultValue) { }
    }
    public interface IMetadataProvider
    {
        System.Threading.Tasks.Task<Orc.Metadata.IObjectWithMetadata> GetMetadataAsync(object obj);
    }
    public interface IMetadataValue
    {
        Orc.Metadata.IMetadata Metadata { get; }
        object ObjectValue { get; set; }
    }
    public interface IMetadataValue<TValue> : Orc.Metadata.IMetadataValue
    {
        TValue Value { get; set; }
    }
    public interface IObjectWithMetadata
    {
        object Instance { get; }
        Orc.Metadata.IMetadataCollection MetadataCollection { get; }
        object GetMetadataValue(string key);
        bool SetMetadataValue(string key, object value);
    }
    public static class IObjectWithMetadataExtensions
    {
        public static System.Collections.Generic.Dictionary<string, Orc.Metadata.IMetadataValue> ToStaticMetadataDictionary(this Orc.Metadata.IObjectWithMetadata objectWithMetadata) { }
        public static System.Collections.Generic.List<Orc.Metadata.IMetadataValue> ToStaticMetadataList(this Orc.Metadata.IObjectWithMetadata objectWithMetadata) { }
        public static System.Collections.Generic.List<Orc.Metadata.IMetadataValue> ToStaticMetadataList(this System.Collections.Generic.Dictionary<string, Orc.Metadata.IMetadataValue> metadataDictionary) { }
    }
    public abstract class MetadataCollectionBase : Orc.Metadata.IMetadataCollection, System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata>, System.Collections.IEnumerable
    {
        protected MetadataCollectionBase() { }
        public abstract System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata> All { get; }
        public virtual Orc.Metadata.IMetadata GetMetadata(string metadataName) { }
    }
    public class MetadataProvider : Orc.Metadata.IMetadataProvider
    {
        public MetadataProvider() { }
        public virtual System.Threading.Tasks.Task<Orc.Metadata.IObjectWithMetadata> GetMetadataAsync(object obj) { }
    }
    [System.Diagnostics.DebuggerDisplay("{Metadata.Name} => {ObjectValue}")]
    public class MetadataValue : Orc.Metadata.IMetadataValue
    {
        public MetadataValue(Orc.Metadata.IMetadata metadata) { }
        public Orc.Metadata.IMetadata Metadata { get; }
        public virtual object ObjectValue { get; set; }
    }
    [System.Diagnostics.DebuggerDisplay("{Metadata.Name} => {Value}")]
    public class MetadataValue<TValue> : Orc.Metadata.MetadataValue, Orc.Metadata.IMetadataValue, Orc.Metadata.IMetadataValue<TValue>
    {
        public MetadataValue(Orc.Metadata.IMetadata metadata) { }
        public TValue Value { get; set; }
        public override object ObjectValue { get; set; }
    }
    public class ObjectWithMetadata : Orc.Metadata.IObjectWithMetadata
    {
        public ObjectWithMetadata(object instance, Orc.Metadata.IMetadataCollection metadataCollection) { }
        public object Instance { get; }
        public Orc.Metadata.IMetadataCollection MetadataCollection { get; }
        public virtual object GetMetadataValue(string key) { }
        protected object GetMetadataValueWithInstance(object instance, string key) { }
        public virtual bool SetMetadataValue(string key, object value) { }
        protected bool SetMetadataValueWithInstance(object instance, string key, object value) { }
    }
    public class ReflectionMetadata : Orc.Metadata.IMetadata
    {
        public ReflectionMetadata(System.Reflection.PropertyInfo propertyInfo) { }
        public string Name { get; }
        public virtual System.Type Type { get; }
        public virtual string DisplayName { get; set; }
        public virtual object GetValue(object instance) { }
        public bool GetValue<TValue>(object instance, out TValue value) { }
        public virtual void SetValue(object instance, object value) { }
        public bool SetValue<TValue>(object instance, TValue value) { }
    }
    public class ReflectionMetadataCollection : Orc.Metadata.MetadataCollectionBase
    {
        public ReflectionMetadataCollection(System.Type type) { }
        public override System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata> All { get; }
    }
    public class ReflectionObjectWithMetadata : Orc.Metadata.ObjectWithMetadata
    {
        public ReflectionObjectWithMetadata(object instance) { }
    }
}