using Microsoft.EntityFrameworkCore;
using UMFG.MinhaPrimeira.API.Repositorio.Context;

namespace UMFG.MinhaPrimeira.API.Apresentacao.MinimalAPI.Extensions
{
    internal static class DatabaseExtensions
    {
        internal static void AddMySqlContext(this IServiceCollection services)
        {
            var connection = "Server=localhost;Port=3307;Database=umfg;Uid=root;Pwd=root;";
            services.AddDbContext<MySqlDatabaseContext>(options
                => options.UseMySQL(connection), ServiceLifetime.Singleton);
        }
    }
}
