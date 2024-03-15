using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;
using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Servicos;

namespace UMFG.MinhaPrimeira.API.Servico.Classes
{
    public sealed class ProdutoServico : IProdutoServico
    {
        private readonly ICollection<Produto> _produtos 
            = new List<Produto>();

        public Produto CadastrarProduto(Produto produto)
        {
            _produtos.Add(produto);
            return produto;
        }

        public Produto ObterPorEan(string ean)
            => _produtos.FirstOrDefault(x => x.EAN == ean)
            ?? throw new ArgumentNullException("Produto não encontrado!");

        public IEnumerable<Produto> ObterTodos() 
            => _produtos.AsEnumerable();

        public void RemoverPorEan(string ean)
            => _produtos.Remove(ObterPorEan(ean));
    }
}
