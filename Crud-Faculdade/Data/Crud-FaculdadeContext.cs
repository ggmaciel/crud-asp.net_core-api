using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crud_Faculdade.Domain;

namespace Crud_Faculdade.Data
{
    public class Crud_FaculdadeContext : DbContext
    {

        public Crud_FaculdadeContext(DbContextOptions<Crud_FaculdadeContext> options) : base(options)
        {

        }


        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Professor> Professor { get; set; }
    }
}
