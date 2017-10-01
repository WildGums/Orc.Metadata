[assembly: System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly: System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETFramework,Version=v4.5", FrameworkDisplayName=".NET Framework 4.5")]


public class static ModuleInitializer
{
    public static void Initialize() { }
}
namespace Orc.Metadata
{
    
    public class DictionaryMetadata : Orc.Metadata.IMetadata
    {
        public DictionaryMetadata() { }
        public DictionaryMetadata(string key, System.Type expectedType) { }
        public virtual string DisplayName { get; set; }
        public virtual string Name { get; }
        public virtual System.Type Type { get; }
        public virtual object GetValue(object instance) { }
        public virtual void SetValue(object instance, object value) { }
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
    public interface IMetadata
    {
        string DisplayName { get; set; }
        string Name { get; }
        System.Type Type { get; }
        object GetValue(object instance);
        void SetValue(object instance, object value);
    }
    public interface IMetadataCollection : System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata>, System.Collections.IEnumerable
    {
        System.Collections.Generic.IEnumerable<Orc.Metadata.IMetadata> All { get; }
        Orc.Metadata.IMetadata GetMetadata(string propertyName);
    }
    public class static IMetadataExtensions
    {
        public static TValue GetValue<TValue>(this Orc.Metadata.IMetadata metadata, object instance) { }
    }
    public interface IMetadataProvider
    {
        System.Threading.Tasks.Task<Orc.Metadata.IObjectWithMetadata> GetMetadataAsync(object obj);
    }
    public interface IMetadataValue
    {
        Orc.Metadata.IMetadata Metadata { get; }
        object Value { get; set; }
    }
    public interface IObjectWithMetadata
    {
        object Instance { get; }
        Orc.Metadata.IMetadataCollection MetadataCollection { get; }
        object GetMetadataValue(string key);
        bool SetMetadataValue(string key, object value);
    }
    public class static IObjectWithMetadataExtensions
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
    [System.Diagnostics.DebuggerDisplayAttribute("{Metadata.Name} => {Value}")]
    public class MetadataValue : Orc.Metadata.IMetadataValue
    {
        public MetadataValue(Orc.Metadata.IMetadata metadata) { }
        public Orc.Metadata.IMetadata Metadata { get; }
        public object Value { get; set; }
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
        public virtual string DisplayName { get; set; }
        public string Name { get; }
        public virtual System.Type Type { get; }
        public virtual object GetValue(object instance) { }
        public virtual void SetValue(object instance, object value) { }
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