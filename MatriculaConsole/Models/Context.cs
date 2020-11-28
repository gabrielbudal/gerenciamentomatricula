using Matricula.MatriculaConsole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaConsole.Models
{
    class Context : DbContext
    {
        public DbSet<Mentor> Mentores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<MentorDisciplina> MentorDisciplinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;Database=Matricula;Trusted_Connection=true");
        }
    }
}
