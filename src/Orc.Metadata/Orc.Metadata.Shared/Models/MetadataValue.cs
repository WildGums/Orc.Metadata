// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataValue.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
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