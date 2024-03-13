using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMFG.MinhaPrimeira.API.Dominio.Entidades
{
    public sealed class Produto : AbstractEntidade
    {
        public string EAN { get; private set; }
        public string Descricao { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }

        /// <summary>
        /// Para entity framework
        /// </summary>
        private Produto() : base() { }

        public Produto(string ean,
            string descricao, 
            decimal precoCusto,
            decimal precoVenda,
            string usuario) : base (usuario)
        {
            SetEan(ean);
            SetDescricao(descricao);
            SetPrecoCusto(precoCusto);
            SetPrecoVenda(precoVenda);
        }

        private void SetPrecoVenda(decimal precoVenda)
        {
            if (precoVenda < 0.01m)
                throw new ArgumentException($"Valor de custo informado é inválido {precoVenda}! Verfique.");

            PrecoVenda = precoVenda;
        }

        private void SetPrecoCusto(decimal precoCusto)
        {
            if (precoCusto < 0.01m)
                throw new ArgumentException($"Valor de custo informado é inválido {precoCusto}! Verfique.");

            PrecoCusto = precoCusto;
        }

        private void SetDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentNullException(nameof(descricao));

            Descricao = descricao;
        }

        private void SetEan(string ean)
        {
            if (string.IsNullOrWhiteSpace(ean))
                throw new ArgumentNullException(nameof(ean));

            if (ean.Length != 12)
                throw new ArgumentException("EAN deve possuir 12 caracteres!");

            EAN = ean;
        }
    }
}