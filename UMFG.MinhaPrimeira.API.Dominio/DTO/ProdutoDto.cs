using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UMFG.MinhaPrimeira.API.Dominio.DTO
{
    public sealed class ProdutoDto
    {
        [JsonPropertyName("ean")]
        public string EAN { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("precoCusto")]
        public decimal PrecoCusto { get; set; }

        [JsonPropertyName("precoVenda")]
        public decimal PrecoVenda { get; set; }

        [JsonPropertyName("usuario")]
        public string Usuario { get; set; }
    }
}
