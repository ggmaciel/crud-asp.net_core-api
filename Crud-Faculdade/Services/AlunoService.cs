using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_Faculdade.Data;
using Crud_Faculdade.Domain;
using Crud_Faculdade.Services.Errors;
using Microsoft.EntityFrameworkCore;

namespace Crud_Faculdade.Services
{
    public class AlunoService
    {
        private readonly Crud_FaculdadeContext _context;

        public AlunoService(Crud_FaculdadeContext context)
        {
            _context = context;
        }

        public List<Aluno> GetAlunos()
        {
            return _context.Aluno.Include(d => d.Disciplinas).ThenInclude(p => p.Professor).ToList();
        }

        public Aluno GetAluno(int id)
        {
            if (!AlunoExists(id))
            {
                throw new AlunoError(404, "Aluno não existe");
            };

            var aluno = _context.Aluno.Include(d => d.Disciplinas)
                .ThenInclude(p => p.Professor).FirstOrDefault(x => x.Id == id);

            return aluno;
        }

        public async Task<Aluno> CreateAluno(Aluno aluno)
        {
            if (AlunoWithEmailExists(aluno.Email))
            {
                throw new AlunoError(400, "Email já existe");
            }

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> UpdateAluno(int id, string senha)
        {
            if (!AlunoExists(id))
            {
                throw new AlunoError(404, "Aluno não existe");
            };

            var aluno = await _context.Aluno.FirstOrDefaultAsync(x => x.Id == id);

            aluno.Senha = senha;

            _context.Aluno.Update(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> DeleteAluno(int id)
        {
            try
            {
                if (!AlunoExists(id))
                {
                    throw new AlunoError(404, "Aluno não existe");
                };

                var aluno = await _context.Aluno.FirstOrDefaultAsync(x => x.Id == id);

                _context.Aluno.Remove(aluno);

                await _context.SaveChangesAsync();

                return aluno;
            }
            catch (DbUpdateException)
            {
                throw new AlunoDbUpdateException(400,
                    "Aluno não pode ser deletado se estiver associado a outras entidades");
            }
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }

        private bool AlunoWithEmailExists(string email)
        {
            return _context.Aluno.Any(e => e.Email == email);
        }
    }
}
