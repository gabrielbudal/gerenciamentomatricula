using Matricula.MatriculaConsole.Models;
using MatriculaConsole.DAL;
using MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matricula.MatriculaConsole.DAL
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
        //public static MentorDisciplina BuscarMentorDisciplina(Mentor mentor)//falta verificar disciplina tb
        //{
        //return MentorDisciplinas.FirstOrDefault(x => x.Mentor == mentor);
        //foreach (Cliente clienteCadastrado in clientes)
        //{
        //    if (clienteCadastrado.Cpf == cpf)
        //    {
        //        return clienteCadastrado;
        //    }
        //}
        //return null;
        //}
    }
}
