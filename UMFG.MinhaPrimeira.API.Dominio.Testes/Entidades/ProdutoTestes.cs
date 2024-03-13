using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;

namespace UMFG.MinhaPrimeira.API.Dominio.Testes.Entidades
{
    [TestClass]
    public sealed class ProdutoTestes
    {
        private const string _owner = "Juliano Maciel";
        private const string _categoryCadastro = "Cadastro de Produto";

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
    }
}