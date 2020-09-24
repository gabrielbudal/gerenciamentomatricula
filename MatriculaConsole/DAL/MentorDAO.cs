using Matricula.MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matricula.MatriculaConsole.DAL
{
    class MentorDAO
    {
        private static List<Mentor> mentores = new List<Mentor>();
        public static List<Mentor> Listar() => mentores;
        public static bool Cadastrar(Mentor m)
        {
            if (BuscarMentor(m.Cpf) == null)
            {
                mentores.Add(m);
                return true;
            }
            return false;
        }
        public static Mentor BuscarMentor(string cpf)
        {
            return mentores.FirstOrDefault(x => x.Cpf == cpf);
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
