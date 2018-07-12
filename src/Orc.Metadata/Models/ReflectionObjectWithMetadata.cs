// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionObjectWithMetadata.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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