using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Domain
{
    public class Nota
    {
        public int Id { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public int PrimeiraNota { get; set; }
        public int SegundaNota { get; set; }
        public int NotaAtividade { get; set; }

        public Nota()
        {

        }

        public Nota(int id, Aluno aluno, Disciplina disciplina, int primeiraNota, int segundaNota, int notaAtividade)
        {
            Id = id;
            Aluno = aluno;
            Disciplina = disciplina;
            PrimeiraNota = primeiraNota;
            SegundaNota = segundaNota;
            NotaAtividade = notaAtividade;
        }
    }
}
