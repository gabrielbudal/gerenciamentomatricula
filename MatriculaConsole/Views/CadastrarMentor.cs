using Matricula.MatriculaConsole.DAL;
using Matricula.MatriculaConsole.Models;
using Matricula.MatriculaConsole.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Views
{
    class CadastrarMentor
    {
        public static void Renderizar()
        {
            Mentor m = new Mentor();
            Console.WriteLine(" ---- CADASTRAR MENTOR ---- \n");
            Console.WriteLine("Digite o nome do mentor:");
            m.Nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf do mentor:");
            m.Cpf = Console.ReadLine();
            if (Validacao.ValidarCpf(m.Cpf))
            {
                if (MentorDAO.Cadastrar(m))
                {
                    Console.WriteLine("Mentor cadastrado com sucesso!!!");
                }
                else
                {
                    Console.WriteLine("Esse mentor já existe!!!");
                }
            }
            else
            {
                Console.WriteLine("CPF inválido!!!");
            }
        }
    }
}
