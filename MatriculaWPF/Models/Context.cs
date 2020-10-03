using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaWPF.Models
{
    class Context : DbContext
    {
        public DbSet<Mentor> Mentores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<MentorDisciplina> MentorDisciplinas { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<HistoricoAluno> HistoricoAlunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;Database=MatriculaWPF;Trusted_Connection=true");
        }
    }
}
