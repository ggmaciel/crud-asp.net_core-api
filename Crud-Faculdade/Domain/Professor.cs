using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Domain
{
    public class Professor : Usuario
    {
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public Professor()
        {

        }

        public Professor(int id, string nome, string telefone, string senha, string email)
            : base(id, nome, telefone, senha, email)
        {

        }
    }
}
