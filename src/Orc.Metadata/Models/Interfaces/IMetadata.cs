namespace Orc.Metadata
{
    using System;
    using System.Diagnostics.CodeAnalysis;

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
        /// Gets the value from the object.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value retrieved.</param>
        /// <returns><c>true</c> if the value was successfully retrieved; otherwise <c>false</c>.</returns>
        bool TryGetValue<TValue>(object instance, out TValue? value);

        /// <summary>
        /// Sets the value of the object.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value to set.</param>
        /// <returns><c>true</c> if the value was successfully retrieved; otherwise <c>false</c>.</returns>/param>
        /// <returns></returns>
        bool TrySetValue<TValue>(object instance, TValue value);

        /// <summary>
        /// Gets the type of the metadata.
        /// </summary>
        /// <value>The type.</value>
        Type Type { get; }
    }
}
