using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Domain
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public Usuario()
        {

        }

        protected Usuario(int id, string nome, string telefone, string senha, string email)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Senha = senha;
            Email = email;
        }
    }
}
