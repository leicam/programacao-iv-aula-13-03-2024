using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Repositorios;
using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Servicos;
using UMFG.MinhaPrimeira.API.Repositorio.Classes;
using UMFG.MinhaPrimeira.API.Servico.Classes;

namespace UMFG.MinhaPrimeira.API.Apresentacao.MinimalAPI.Extensions
{
    internal static class ServicesExtensions
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddSingleton<IProdutoServico, ProdutoServico>();
        }
    }
}