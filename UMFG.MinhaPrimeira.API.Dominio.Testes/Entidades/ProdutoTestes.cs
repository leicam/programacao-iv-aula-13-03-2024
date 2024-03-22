using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;
using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Repositorios;
using UMFG.MinhaPrimeira.API.Repositorio.Classes;
using UMFG.MinhaPrimeira.API.Repositorio.Context;

namespace UMFG.MinhaPrimeira.API.Dominio.Testes.Entidades
{
    [TestClass]
    public sealed class ProdutoTestes
    {
        private const string _owner = "Juliano Maciel";
        private const string _categoryCadastro = "Cadastro de Produto";
        private const string _categoryDataBase = "Banco de Dados";

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        public void Instanciar_Produto_Valido()
        {
            try
            {
                var produto = new Produto(
                    "100000000001",
                    "PRODUTO TESTE 1",
                    29.90m,
                    49.90m,
                    "usuario.teste@mail.com.br");

                Assert.IsNotNull(produto.Id);
                Assert.AreEqual("100000000001", produto.EAN);
                Assert.AreEqual("PRODUTO TESTE 1", produto.Descricao);
                Assert.AreEqual(29.90m, produto.PrecoCusto);
                Assert.AreEqual(49.90m, produto.PrecoVenda);
                Assert.AreEqual("usuario.teste@mail.com.br", produto.UsuarioCadastro);
                Assert.AreEqual("usuario.teste@mail.com.br", produto.UsuarioAlteracao);
                Assert.IsTrue(produto.DataCadastro >= DateTime.Today);
                Assert.IsTrue(produto.DataAlteracao >= DateTime.Today);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("       ")]
        public void Produto_EAN_Invalido(string ean)
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Produto(
                        ean,
                        "PRODUTO TESTE 1",
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        public void Produto_EAN_QuantidadeCaractereInvalido()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new Produto(
                        "10000000000",
                        "PRODUTO TESTE 1",
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("       ")]
        public void Produto_Descricao_Invalido(string descricao)
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Produto(
                        "100000000001",
                        descricao,
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        public void Produto_PrecoCusto_InvalidoValorNegativo()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new Produto(
                        "100000000001",
                        "PRODUTO TESTE 1",
                        -0.01m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        public void Produto_PrecoCusto_InvalidoValorZerado()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new Produto(
                        "100000000001",
                        "PRODUTO TESTE 1",
                        0.00m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        public void Produto_PrecoVenda_InvalidoValorNegativo()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new Produto(
                        "100000000001",
                        "PRODUTO TESTE 1",
                        29.90m,
                        -0.01m,
                        "usuario.teste@mail.com.br"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryCadastro)]
        public void Produto_PrecoVenda_InvalidoValorZerado()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new Produto(
                        "100000000001",
                        "PRODUTO TESTE 1",
                        29.90m,
                        0.00m,
                        "usuario.teste@mail.com.br"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryDataBase)]
        public void Produto_AdicionarDataBase_Valido()
        {
            var repositorio = ObterProdutoRepositorio();
            var produto = new Produto(
                        "100000000001",
                        "PRODUTO TESTE 1",
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br");

            repositorio.Adicionar(produto);
            repositorio.SaveChanges();

            var produtoDataBase = repositorio.ObterPorEan("100000000001");

            Assert.AreEqual("100000000001", produtoDataBase.EAN);
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryDataBase)]
        public void Produto_RemoverDataBase_Valido()
        {
            var repositorio = ObterProdutoRepositorio();
            var produto = new Produto(
                        "100000000002",
                        "PRODUTO TESTE 1",
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br");

            repositorio.Adicionar(produto);
            repositorio.SaveChanges();

            repositorio.Remover(repositorio.ObterPorEan("100000000002"));
            repositorio.SaveChanges();

            Assert.ThrowsException<ArgumentException>(() =>
                repositorio.ObterPorEan("100000000002"));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryDataBase)]
        public void Produto_ObterTodosDataBase_Valido()
        {
            var repositorio = ObterProdutoRepositorio();

            repositorio.Adicionar(new Produto(
                        "100000000003",
                        "PRODUTO TESTE 1",
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
            repositorio.Adicionar(new Produto(
                        "100000000004",
                        "PRODUTO TESTE 1",
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
            repositorio.SaveChanges();

            var lista = repositorio.ObterTodos();

            Assert.IsTrue(lista.Any());
            Assert.AreEqual(2, lista
                .Where(x => x.EAN == "100000000003" || x.EAN == "100000000004")
                .Count());
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_categoryDataBase)]
        public void Produto_ObterPorEanDataBase_Valido()
        {
            var repositorio = ObterProdutoRepositorio();

            repositorio.Adicionar(new Produto(
                        "100000000005",
                        "PRODUTO TESTE 5",
                        29.90m,
                        49.90m,
                        "usuario.teste@mail.com.br"));
            repositorio.SaveChanges();

            var produtoDataBase = repositorio.ObterPorEan("100000000005");

            Assert.IsNotNull(produtoDataBase);
            Assert.IsNotNull(produtoDataBase.Id);
            Assert.AreEqual("100000000005", produtoDataBase.EAN);
            Assert.AreEqual("PRODUTO TESTE 5", produtoDataBase.Descricao);
            Assert.AreEqual(29.90m, produtoDataBase.PrecoCusto);
            Assert.AreEqual(49.90m, produtoDataBase.PrecoVenda);
            Assert.AreEqual("usuario.teste@mail.com.br", produtoDataBase.UsuarioCadastro);
            Assert.AreEqual("usuario.teste@mail.com.br", produtoDataBase.UsuarioAlteracao);
            Assert.IsTrue(produtoDataBase.DataCadastro >= DateTime.Today);
            Assert.IsTrue(produtoDataBase.DataAlteracao >= DateTime.Today);
        }

        private IProdutoRepositorio ObterProdutoRepositorio()
            => new ProdutoRepositorio(new MySqlDatabaseContext(ObterProvider()));

        private DbContextOptions<MySqlDatabaseContext> ObterProvider()
            => new DbContextOptionsBuilder<MySqlDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "umfg_teste_unitario")
                .Options;
    }
}