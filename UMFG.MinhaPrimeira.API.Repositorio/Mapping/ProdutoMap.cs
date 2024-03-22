using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;

namespace UMFG.MinhaPrimeira.API.Repositorio.Mapping
{
    internal sealed class ProdutoMap : AbstractEntidadeMap<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.ToTable("PRODUTO");

            builder.Property(x => x.PrecoCusto).HasColumnName("VL_CUSTO");
            builder.Property(x => x.PrecoVenda).HasColumnName("VL_VENDA");
            builder.Property(x => x.EAN).HasColumnName("CD_EAN");
            builder.Property(x => x.Descricao).HasColumnName("DS_PRODUTO");

            builder.Property(x => x.PrecoCusto).IsRequired();
            builder.Property(x => x.PrecoVenda).IsRequired();
            builder.Property(x => x.EAN).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
        }
    }
}