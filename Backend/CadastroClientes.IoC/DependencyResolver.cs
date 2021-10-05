using CadastroClientes.Application;
using CadastroClientes.Application.Interfaces;
using CadastroClientes.Repository.Repositories;
using CadastroClientes.Repository.Repositories.Interfaces;
using CadastroClientes.Services;
using CadastroClientes.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroClientes.IoC
{
    public static class DependencyResolver
    {
        public static void AddInjectionContainer(this IServiceCollection services)
        {
            AddAplicationContainer(services);
            AddServicesContainer(services);
            AddRepositoriesContainer(services);
        }

        private static void AddAplicationContainer(IServiceCollection services)
        {
            services.AddTransient<IPessoaApplication, PessoaApplication>();
        }

        private static void AddServicesContainer(IServiceCollection services)
        {
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaTelefoneService, PessoaTelefoneService>();
        }

        private static void AddRepositoriesContainer(IServiceCollection services)
        {
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IPessoaTelefoneRepository, PessoaTelefoneRepository>();
        }
    }
}
