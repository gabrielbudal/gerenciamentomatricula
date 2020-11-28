using Matricula.MatriculaConsole.DAL;
using Matricula.MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaConsole.Views
{
    class ListarMentor
    {
        public static void Renderizar()
        {
            Console.WriteLine("Lista de Disciplina:\n");
            foreach (Mentor mentorCadastrado in MentorDAO.Listar())
            {
                Console.WriteLine(mentorCadastrado);
            }
        }
    }
}
