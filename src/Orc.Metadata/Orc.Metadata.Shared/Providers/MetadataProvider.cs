// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Threading.Tasks;
    using Catel.Threading;

    public class MetadataProvider : IMetadataProvider
    {
        [ObsoleteEx(RemoveInVersion = "1.1.0", TreatAsErrorFromVersion = "1.0.1", ReplacementTypeOrMember = "GetMetadataAsync")]
        public virtual IObjectWithMetadata GetMetadata(object obj)
        {
            // By default we use reflection, user can always register their own IMetadataProvider
            return new ReflectionObjectWithMetadata(obj);
        }

        public virtual Task<IObjectWithMetadata> GetMetadataAsync(object obj)
        {
            return TaskHelper<IObjectWithMetadata>.FromResult(GetMetadata(obj));
        }
    }
}