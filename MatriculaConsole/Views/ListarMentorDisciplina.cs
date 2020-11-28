using Matricula.MatriculaConsole.DAL;
using Matricula.MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaConsole.Views
{
    class ListarMentorDisciplina
    {
        public static void Renderizar()
        {
            Console.WriteLine("Listagem relação de mentores e disciplinas:\n");
            foreach (MentorDisciplina relacaoCadastrada in MentorDisciplinaDAO.Listar())
            {
                Console.WriteLine(relacaoCadastrada);
            }
        }
    }
}
