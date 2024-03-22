using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;

namespace UMFG.MinhaPrimeira.API.Dominio.Interfaces.Repositorios
{
    public interface IAbstractRepositorio<T> where T : AbstractEntidade
    {
        void Adicionar(T entidade);
        void Remover(T entidade);
        IEnumerable<T> ObterTodos();
        void SaveChanges();
    }
}