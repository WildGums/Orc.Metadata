// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public class MetadataProvider : IMetadataProvider
    {
        public virtual IObjectWithMetadata GetMetadata(object obj)
        {
            // By default we use reflection, user can always register their own IMetadataProvider
            return new ReflectionObjectWithMetadata(obj);
        }
    }
}