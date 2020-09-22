using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class Aluno
    {
        //Contrutores
        public Aluno()
        {
        }
        //Atributos, propriedades e características
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public Boolean Ativo { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} | Cpf: {Cpf}, Data de Nascimento: {DtNascimento} ";
        }
    }
}
