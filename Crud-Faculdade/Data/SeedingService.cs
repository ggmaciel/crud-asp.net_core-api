using Crud_Faculdade.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Faculdade.Data
{
    public class SeedingService
    {
        private readonly Crud_FaculdadeContext _context;

        public SeedingService(Crud_FaculdadeContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Aluno.Any() || _context.Disciplina.Any() ||
                _context.Nota.Any() || _context.Professor.Any())
            {
                return;
            }

            Aluno alu1 = new Aluno(1, "Gustavo", "99999-9999", "123456", "gustavo@email.com",
                0, "ADS", "123456789", "1°");
            Aluno alu2 = new Aluno(2, "Paulo", "99999-9999", "123456", "paulo@email.com",
               0, "ADS", "123456789", "1°");

            Professor prof1 = new Professor(1, "Marcello", "99999-9999", "123456", "marcello@email.com");

            Disciplina dis1 = new Disciplina(1, "Banco de Dados", 60, "18:30 - 21:10", "Noturno", prof1, 2);


            Nota nota1 = new Nota(1, alu1, dis1, 10, 10, 10);

            alu1.Notas.Add(nota1);
            alu1.Disciplinas.Add(dis1);

            dis1.Alunos.Add(alu1);
            dis1.Notas.Add(nota1);


            _context.AddRange(alu1, alu2, prof1, dis1, nota1);

            _context.SaveChanges();




        }
    }
}
