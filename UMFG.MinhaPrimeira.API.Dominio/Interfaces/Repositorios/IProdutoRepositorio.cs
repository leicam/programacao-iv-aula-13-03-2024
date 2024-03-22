using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;

namespace UMFG.MinhaPrimeira.API.Dominio.Interfaces.Repositorios
{
    public interface IProdutoRepositorio : IAbstractRepositorio<Produto>
    {
        Produto ObterPorEan(string ean);
    }
}
