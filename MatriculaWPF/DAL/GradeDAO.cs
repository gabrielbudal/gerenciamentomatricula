using MatriculaWPF.Models;
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
        public static List<Grade> Listar() => _context.Grades.ToList();
        public static Grade BuscarGrade(Grade grade) => _context.Grades.Where(g => g.Turma == grade.Turma && g.MentorDisciplina == grade.MentorDisciplina && g.Dia == grade.Dia)
                    .FirstOrDefault();
        public static Grade BuscarTurmaPorId(int id) => _context.Grades.Where(g => g.Id == id)
                    .FirstOrDefault();
    }
}
