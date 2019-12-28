// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataValue.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public interface IMetadataValue
    {
        IMetadata Metadata { get; }
        object ObjectValue { get; set; }
    }

    public interface IMetadataValue<TValue> : IMetadataValue
    {
        TValue Value { get; set; }
    }
}
