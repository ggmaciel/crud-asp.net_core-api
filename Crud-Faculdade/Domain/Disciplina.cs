using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Domain
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public string Horario { get; set; }
        public string Turno { get; set; }
        public Professor Professor { get; set; }
        public int NumeroAlunos { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();

        public Disciplina()
        {

        }

        public Disciplina(int id, string nome, int cargaHoraria, string horario, string turno, Professor professor, int numeroAlunos)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            Horario = horario;
            Turno = turno;
            Professor = professor;
            NumeroAlunos = numeroAlunos;
        }
    }
}
