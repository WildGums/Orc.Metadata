// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataValue.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{Metadata.Name} => {Value}")]
    public class MetadataValue : IMetadataValue
    {
        public MetadataValue(IMetadata metadata)
        {
            Metadata = metadata;
        }

        public IMetadata Metadata { get; private set; }

        public object Value { get; set; }
    }
}