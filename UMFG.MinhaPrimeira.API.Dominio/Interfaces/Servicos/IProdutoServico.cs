using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;

namespace UMFG.MinhaPrimeira.API.Dominio.Interfaces.Servicos
{
    public interface IProdutoServico
    {
        Produto CadastrarProduto(Produto produto);
        IEnumerable<Produto> ObterTodos();
        Produto ObterPorEan(string ean);
        void RemoverPorEan(string ean);
    }
}