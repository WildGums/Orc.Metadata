// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Threading.Tasks;

    public interface IMetadataProvider
    {
        [ObsoleteEx(RemoveInVersion = "1.2.0", TreatAsErrorFromVersion = "1.1.0", ReplacementTypeOrMember = "GetMetadataAsync")]
        IObjectWithMetadata GetMetadata(object obj);
        Task<IObjectWithMetadata> GetMetadataAsync(object obj);
    }
}