using Domain.Interfaces;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;

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
            service.AddScoped<IServicosProduto, ServicosProduto>();

            return service;
        }
    }
}
