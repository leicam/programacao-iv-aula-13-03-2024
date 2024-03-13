using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMFG.MinhaPrimeira.API.Dominio.Entidades
{
    public abstract class AbstractEntidade
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string UsuarioCadastro { get; private set; }
        public string UsuarioAlteracao { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
        public DateTime DataAlteracao { get; private set; } = DateTime.Now;

        //para o entity framework
        protected AbstractEntidade() { }

        protected AbstractEntidade(string usuario)
        {
            UsuarioCadastro = usuario;
            UsuarioAlteracao = usuario;
        }
    }
}