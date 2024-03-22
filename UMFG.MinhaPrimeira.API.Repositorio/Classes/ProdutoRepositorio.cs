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
    public sealed class ProdutoRepositorio : AbstractRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(MySqlDatabaseContext context) : base(context) { }

        public Produto ObterPorEan(string ean) 
            => Entidade.FirstOrDefault(x => x.EAN == ean)
            ?? throw new ArgumentException("Produto não encontrado!");
    }
}
