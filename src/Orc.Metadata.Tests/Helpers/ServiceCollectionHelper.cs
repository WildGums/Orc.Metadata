namespace Orc.Wizard.Tests
{
    using Catel;
    using Microsoft.Extensions.DependencyInjection;
    using Orc.Metadata;

    internal static class ServiceCollectionHelper
    {
        public static IServiceCollection CreateServiceCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging();
            serviceCollection.AddCatelCore();
            serviceCollection.AddOrcMetadata();

            return serviceCollection;
        }
    }
}
