// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataProvider.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Threading.Tasks;
    using Catel.Threading;

    public class MetadataProvider : IMetadataProvider
    {
        public virtual Task<IObjectWithMetadata> GetMetadataAsync(object obj)
        {
            // By default we use reflection, user can always register their own IMetadataProvider
            return TaskHelper<IObjectWithMetadata>.FromResult(new ReflectionObjectWithMetadata(obj));
        }
    }
}