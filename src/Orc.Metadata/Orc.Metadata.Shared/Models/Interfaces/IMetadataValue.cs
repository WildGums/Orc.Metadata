// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataValue.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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