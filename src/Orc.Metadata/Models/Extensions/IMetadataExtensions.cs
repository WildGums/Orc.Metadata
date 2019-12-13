// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetadataExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    public static class IMetadataExtensions
    {
        [ObsoleteEx(ReplacementTypeOrMember = "bool GetValue<TValue>(object, out TValue, TValue)", TreatAsErrorFromVersion = "3.0", RemoveInVersion = "4.0")]
        public static TValue GetValue<TValue>(this IMetadata metadata, object instance)
        {
            return (TValue) metadata.GetValue(instance);
        }

        /// <summary>
        /// Gets the value from the object.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="metadata">The metadata.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value retrieved.</param>
        /// <param name="defaultValue">The default value which will be assigned to <paramref name="value"/> if the value is not retreived successfully.</param>
        /// <returns><c>true</c> if the value was successfully retrieved; otherwise <c>false</c>.</returns>
        public static bool GetValue<TValue>(this IMetadata metadata, object instance, out TValue value, TValue defaultValue)
        {
            if (!metadata.GetValue<TValue>(instance, out value))
            {
                value = defaultValue;
                return false;
            }

            return true;
        }
    }
}
