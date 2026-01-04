namespace Orc.Metadata
{
    using Catel.Services;
    using Catel.ThirdPartyNotices;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /// <summary>
    /// Core module which allows the registration of default services in the service collection.
    /// </summary>
    public static class OrcMetadataModule
    {
        public static IServiceCollection AddOrcMetadata(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IMetadataProvider, MetadataProvider>();

            serviceCollection.AddSingleton<ILanguageSource>(new LanguageResourceSource("Orc.Metadata", "Orc.Metadata.Properties", "Resources"));

            serviceCollection.AddSingleton<IThirdPartyNotice>((x) => new LibraryThirdPartyNotice("Orc.Metadata", "https://github.com/wildgums/orc.metadata"));

            return serviceCollection;
        }
    }
}
