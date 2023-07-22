using desafiodev.cnabreader.application.CnabImporter;
using desafiodev.cnabreader.application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace desafiodev.infra.crosscutting.DI
{
    public static class DependencyInjectionHelper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICnabImporterService, CnabImporterService>();
        }
    }
}