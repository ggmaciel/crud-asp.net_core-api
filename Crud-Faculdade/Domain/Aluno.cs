using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Domain
{
    public class Aluno : Usuario
    {
        public int Faltas { get; set; }
        public string Curso { get; set; }
        public string NumeroDeMatricula { get; set; }
        public string ModAtual { get; set; }
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public Aluno()
        {

        }

        public Aluno(int id, string nome, string telefone, string senha, string email, 
            int faltas, string curso, string numeroDeMatricula, string modAtual) : base(id, nome, telefone, senha, email)
        {
            Faltas = faltas;
            Curso = curso;
            NumeroDeMatricula = numeroDeMatricula;
            ModAtual = modAtual;
        }
    }
}
