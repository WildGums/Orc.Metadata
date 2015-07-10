// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataValue.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public interface IMetadataValue
    {
        #region Properties
        IMetadata Metadata { get; }
        object Value { get; set; }
        #endregion
    }
}