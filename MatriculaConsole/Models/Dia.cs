using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class Dia
    {
        //Contrutores
        public Dia()
        {
        }
        //Atributos, propriedades e características
        public string Descricao { get; set; }
        public override string ToString()
        {
            return $"Dia: {Descricao}";
        }
    }
}
