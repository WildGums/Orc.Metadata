// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public interface IMetadataProvider
    {
        IObjectWithMetadata GetMetadata(object obj);
    }
}