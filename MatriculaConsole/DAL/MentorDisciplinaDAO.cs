using Matricula.MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matricula.MatriculaConsole.DAL
{
    class MentorDisciplinaDAO
    {
        private static List<MentorDisciplina> MentorDisciplinas = new List<MentorDisciplina>();
        public static List<MentorDisciplina> Listar() => MentorDisciplinas;
        public static void Cadastrar(MentorDisciplina mentordisciplina) => MentorDisciplinas.Add(mentordisciplina);
        //public static bool Cadastrar(MentorDisciplina m)
        //{
            //if (BuscarMentorDisciplina(m.Cpf) == null)
            //{
          //      MentorDisciplinas.Add(m);
            //    return true;
            //}
            //return false;
        //}
        public static MentorDisciplina BuscarMentorDisciplina(Mentor mentor)//falta verificar disciplina tb
        {
            return MentorDisciplinas.FirstOrDefault(x => x.Mentor == mentor);
            //foreach (Cliente clienteCadastrado in clientes)
            //{
            //    if (clienteCadastrado.Cpf == cpf)
            //    {
            //        return clienteCadastrado;
            //    }
            //}
            //return null;
        }
    }
}
