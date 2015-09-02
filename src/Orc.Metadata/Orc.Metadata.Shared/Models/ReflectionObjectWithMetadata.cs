// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionObjectWithMetadata.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public class ReflectionObjectWithMetadata : ObjectWithMetadata
    {
        public ReflectionObjectWithMetadata(object instance)
            : base(instance, new ReflectionMetadataCollection(instance.GetType()))
        {
        }
    }
}