using Matricula.MatriculaConsole.DAL;
using Matricula.MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaConsole.Views
{
    class ListarDisciplina
    {
        public static void Renderizar()
        {
            Console.WriteLine("Lista de Disciplina:\n");
            foreach (Disciplina disciplinaCadastrada in DisciplinaDAO.Listar())
            {
                Console.WriteLine(disciplinaCadastrada);
            }
        }
    }
}
