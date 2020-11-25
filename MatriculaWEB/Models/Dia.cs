using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Dia : BaseModel
    {
        //Contrutores
        public Dia()
        {
        }
        //Atributos, propriedades e características
        public string Descricao { get; set; }
        public int Ordenacao { get; set; }
        public override string ToString()
        {
            return $"Dia: {Descricao}";
        }
    }
}
