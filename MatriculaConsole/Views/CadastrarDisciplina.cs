using Matricula.MatriculaConsole.DAL;
using Matricula.MatriculaConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Views
{
    class CadastrarDisciplina
    {
        public static void Renderizar()
        {
            Disciplina d = new Disciplina();
            Console.WriteLine(" ---- CADASTRAR DISCIPLINA ---- \n");
            Console.WriteLine("Digite o nome da disciplina:");
            d.Nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição referente a disciplina:");
            d.Descricao = Console.ReadLine();
            if (DisciplinaDAO.Cadastrar(d))
            {
                Console.WriteLine("Disciplina cadastrada com sucesso!!!");
            }
                else
                {
                    Console.WriteLine("Essa disciplina já existe!!!");
                }
        }
    }
}
