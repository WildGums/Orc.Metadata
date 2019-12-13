﻿// --------------------------------------------------------------------------------------------------------------------
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
        [ObsoleteEx(ReplacementTypeOrMember = "bool GetValue<TValue>(object, out TValue, TValue)", TreatAsErrorFromVersion = "3.0", RemoveInVersion = "4.0")]
        object GetValue(object instance);

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        [ObsoleteEx(ReplacementTypeOrMember = "bool SetValue<TValue>(object, TValue)", TreatAsErrorFromVersion = "3.0", RemoveInVersion = "4.0")]
        void SetValue(object instance, object value);

        /// <summary>
        /// Gets the value from the object.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value retrieved.</param>
        /// <returns><c>true</c> if the value was successfully retrieved; otherwise <c>false</c>.</returns>
        bool GetValue<TValue>(object instance, out TValue value);

        /// <summary>
        /// Sets the value of the object.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value to set.</param>
        /// <returns><c>true</c> if the value was successfully retrieved; otherwise <c>false</c>.</returns>/param>
        /// <returns></returns>
        bool SetValue<TValue>(object instance, TValue value);

        /// <summary>
        /// Gets the type of the metadata.
        /// </summary>
        /// <value>The type.</value>
        Type Type { get; }
    }
}
