using System;
using Matricula.MatriculaConsole.DAL;
using Matricula.MatriculaConsole.Views;
using MatriculaConsole.Views;

namespace Matricula
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dados.Inicializar();
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine(" ---- APLICAÇÃO DE VENDAS ---- \n");
                Console.WriteLine("1 - Cadastrar disciplina");
                Console.WriteLine("2 - Listar disciplina");
                Console.WriteLine("3 - Cadastrar mentor");
                Console.WriteLine("4 - Listar mentor");
                Console.WriteLine("5 - Cadastrar relação mentor e disciplina");
                Console.WriteLine("6 - Listar relação mentor e disciplina");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("\nDigite a opção desejada:");
                opcao = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        CadastrarDisciplina.Renderizar();
                        break;
                    case 2:
                        ListarDisciplina.Renderizar();
                        break;
                    case 3:
                        CadastrarMentor.Renderizar();
                        break;
                    case 4:
                        ListarMentor.Renderizar();
                        break;
                    case 5:
                        CadastrarMentorDisciplina.Renderizar();
                        break;
                    case 6:
                        ListarMentorDisciplina.Renderizar();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...\n");
                        break;
                    default:
                        Console.WriteLine(" ---- OPÇÃO INVÁLIDA!!! ---- \n");
                        break;
                }
                Console.WriteLine("\nPressione uma tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }
    }
}
