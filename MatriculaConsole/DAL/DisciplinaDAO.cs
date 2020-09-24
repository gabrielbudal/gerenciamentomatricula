using Matricula.MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matricula.MatriculaConsole.DAL
{
    class DisciplinaDAO
    {
        private static List<Disciplina> disciplinas = new List<Disciplina>();
        public static List<Disciplina> Listar() => disciplinas;
        public static bool Cadastrar(Disciplina d)
        {
            if (BuscarDisciplina(d.Nome) == null)
            {
                disciplinas.Add(d);
                return true;
            }
            return false;
        }
        public static Disciplina BuscarDisciplina(string nome)
        {
            return disciplinas.FirstOrDefault(x => x.Nome == nome);
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
