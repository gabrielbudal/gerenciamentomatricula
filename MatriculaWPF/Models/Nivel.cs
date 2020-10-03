using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MatriculaWPF.Models
{
    [Table("Niveis")]
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
