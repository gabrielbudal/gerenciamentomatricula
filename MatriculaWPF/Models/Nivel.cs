using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaWPF.Models
{
    class Nivel : BaseModel
    {
        //Contrutores
        public Nivel()
        {
        }
        //Atributos, propriedades e características
        public string Nome { get; set; }
        public int Ordenacao { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} | Ordenacao {Ordenacao} ";
        }
    }
}
