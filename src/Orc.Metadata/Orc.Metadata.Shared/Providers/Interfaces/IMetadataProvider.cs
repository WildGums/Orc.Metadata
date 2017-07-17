// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataProvider.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Threading.Tasks;

    public interface IMetadataProvider
    {
        Task<IObjectWithMetadata> GetMetadataAsync(object obj);
    }
}