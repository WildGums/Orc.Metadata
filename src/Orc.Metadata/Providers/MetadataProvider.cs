namespace Orc.Metadata;

using System;
using System.Threading.Tasks;

public class MetadataProvider : IMetadataProvider
{
    public virtual Task<IObjectWithMetadata> GetMetadataAsync(object obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        // By default we use reflection, user can always register their own IMetadataProvider
        return Task.FromResult<IObjectWithMetadata>(new ReflectionObjectWithMetadata(obj));
    }
}
