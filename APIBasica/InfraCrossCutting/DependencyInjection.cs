using Domain.Interfaces;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InfraCrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(IServiceCollection service)
        {
            //Repositories
            service.AddScoped<IRepositorioProduto, RepositorioProduto>();
            service.AddScoped<IRepositorioCategoria, RepositorioCategoria>();

            //Services

            return service;
        }
    }
}
