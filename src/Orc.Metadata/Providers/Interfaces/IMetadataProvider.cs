namespace Orc.Metadata;

using System.Threading.Tasks;

public interface IMetadataProvider
{
    Task<IObjectWithMetadata> GetMetadataAsync(object obj);
}
