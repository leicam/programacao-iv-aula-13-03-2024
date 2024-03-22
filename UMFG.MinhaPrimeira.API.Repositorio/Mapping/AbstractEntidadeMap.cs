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
    internal abstract class AbstractEntidadeMap<T> : IEntityTypeConfiguration<T> where T : AbstractEntidade
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.DataCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(x => x.DataAlteracao).HasColumnName("DT_ALTERACAO");
            builder.Property(x => x.UsuarioCadastro).HasColumnName("DS_USUARIO_CADASTRO");
            builder.Property(x => x.UsuarioAlteracao).HasColumnName("DS_USUARIO_ALTERACAO");
            
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataAlteracao).IsRequired();
            builder.Property(x => x.UsuarioCadastro).IsRequired();
            builder.Property(x => x.UsuarioAlteracao).IsRequired();
        }
    }
}
