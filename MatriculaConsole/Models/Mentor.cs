using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class Mentor
    {
        //Contrutores
        public Mentor()
        {
        }
        //Atributos, propriedades e características
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} | Cpf: {Cpf}";
        }
    }
}
