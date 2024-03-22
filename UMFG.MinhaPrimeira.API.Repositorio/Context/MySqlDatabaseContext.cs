using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Repositorio.Mapping;

namespace UMFG.MinhaPrimeira.API.Repositorio.Context
{
    public sealed class MySqlDatabaseContext : DbContext
    {
        private const string C_IN_MEMORY_PROVIDER
            = "Microsoft.EntityFrameworkCore.InMemory";

        public MySqlDatabaseContext() => Migrate();

        public MySqlDatabaseContext(DbContextOptions<MySqlDatabaseContext> option)
            : base(option) => Migrate();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }

        private void Migrate()
        {
            if (C_IN_MEMORY_PROVIDER.Equals(Database.ProviderName))
                return;

            if (Database.GetPendingMigrations().Any())
                Database.Migrate();
        }
    }
}