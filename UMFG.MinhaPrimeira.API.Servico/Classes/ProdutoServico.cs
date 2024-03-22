using UMFG.MinhaPrimeira.API.Dominio.Entidades;
using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Repositorios;
using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Servicos;

namespace UMFG.MinhaPrimeira.API.Servico.Classes
{
    public sealed class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;           

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio
                ?? throw new ArgumentNullException(nameof(produtoRepositorio));
        }

        public Produto CadastrarProduto(Produto produto)
        {
            _produtoRepositorio.Adicionar(produto);
            _produtoRepositorio.SaveChanges();

            return produto;
        }

        public Produto ObterPorEan(string ean)
            => _produtoRepositorio.ObterPorEan(ean);

        public IEnumerable<Produto> ObterTodos() 
            => _produtoRepositorio.ObterTodos();

        public void RemoverPorEan(string ean)
        {
            var produto = _produtoRepositorio.ObterPorEan(ean);

            _produtoRepositorio.Remover(produto);
            _produtoRepositorio.SaveChanges();
        }
    }
}
