using Matricula.MatriculaConsole.DAL;
using Matricula.MatriculaConsole.Models;
using Matricula.MatriculaConsole.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Views
{
    class CadastrarMentorDisciplina
    {
        public static void Renderizar()
        {
            MentorDisciplina md = new MentorDisciplina();
            Mentor m = new Mentor();
            Disciplina d = new Disciplina();


            Console.WriteLine("Cadastro de vínculo entre mentor e disciplina\n");
            Console.WriteLine("Digite o Cpf do Mentor:");
            m.Cpf = Console.ReadLine();
            m = MentorDAO.BuscarMentorPorCpf(m.Cpf);
            if (m != null && Validacao.ValidarCpf(m.Cpf))
            {
                md.Mentor = m;
                Console.WriteLine("Digite o nome da disciplina:");
                d.Nome = Console.ReadLine();
                d = DisciplinaDAO.BuscarDisciplinaPorNome(d.Nome);

                if (d != null)
                {
                        md.Disciplina = d;
                        if (MentorDisciplinaDAO.Cadastrar(md))
                        {
                            Console.WriteLine("Atrelamento realizado com sucesso!!!");
                        }
                        else
                        {
                            Console.WriteLine("Atrelamento já existe!!!");
                        }
                }
                else
                {
                    Console.WriteLine("Disciplina não localizada.");
                }


            }
            else
            {
                Console.WriteLine("Mentor não encontrado!");
            }
        }
    }
}
