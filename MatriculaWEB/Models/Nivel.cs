using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Nivel : BaseModel
    {
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
