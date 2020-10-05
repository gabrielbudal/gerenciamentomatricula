using MatriculaWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class GradeDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Grade grade)
        {
            if (BuscarGrade(grade) == null)
            {
                _context.Grades.Add(grade);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<Grade> Listar() => _context.Grades
            .Include(d => d.Dia)
            .Include(t => t.Turma)
                .ThenInclude(n => n.Nivel)
            .ToList();
        public static Grade BuscarGrade(Grade grade) => _context.Grades.Where(g => g.Turma == grade.Turma && g.MentorDisciplina == grade.MentorDisciplina && g.Dia == grade.Dia && g.HorarioInicio == grade.HorarioInicio && g.HorarioFim == grade.HorarioFim)
                    .FirstOrDefault();
        public static Grade BuscarGradePorId(int id) => _context.Grades.Include(t => t.Turma)
                    .Where(g => g.Id == id)
                    .FirstOrDefault();
    }
}
