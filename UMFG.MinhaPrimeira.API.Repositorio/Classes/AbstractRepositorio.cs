using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;
using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Repositorios;
using UMFG.MinhaPrimeira.API.Repositorio.Context;

namespace UMFG.MinhaPrimeira.API.Repositorio.Classes
{
    public abstract class AbstractRepositorio<T> : IAbstractRepositorio<T> where T : AbstractEntidade
    {
        private readonly MySqlDatabaseContext _context;

        public DbSet<T> Entidade => _context.Set<T>();

        public AbstractRepositorio(MySqlDatabaseContext context) 
            => _context = context ?? throw new ArgumentNullException(nameof(context));

        public void Adicionar(T entidade) => Entidade.Add(entidade);
        public IEnumerable<T> ObterTodos() => Entidade.AsEnumerable();
        public void Remover(T entidade) => Entidade.Remove(entidade);
        public void SaveChanges() => _context.SaveChanges();
    }
}
