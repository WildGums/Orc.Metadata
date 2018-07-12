// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadata.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System;

    public interface IMetadata
    {
        /// <summary>
        /// Gets the property name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        string DisplayName { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>System.Instance.</returns>
        object GetValue(object instance);

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        void SetValue(object instance, object value);

        /// <summary>
        /// Gets the type of the metadata.
        /// </summary>
        /// <value>The type.</value>
        Type Type { get; }
    }
}