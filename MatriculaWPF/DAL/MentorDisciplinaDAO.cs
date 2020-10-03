using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class MentorDisciplinaDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(MentorDisciplina mentordisciplina)
        {
            if (BuscarMentorDisciplina(mentordisciplina) == null)
            {
                _context.MentorDisciplinas.Add(mentordisciplina);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<MentorDisciplina> Listar() => _context.MentorDisciplinas.ToList();
        public static MentorDisciplina BuscarMentorDisciplina(MentorDisciplina mentordisciplina) => _context.MentorDisciplinas.Where(md => md.Disciplina == mentordisciplina.Disciplina && md.Mentor == mentordisciplina.Mentor)
                    .FirstOrDefault();
    }
}
