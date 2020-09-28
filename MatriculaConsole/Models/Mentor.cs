using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    [Table("Mentores")]
    class Mentor
    {
        //Contrutores
        public Mentor()
        {
        }
        //Atributos, propriedades e características
        [Key]
        public int MentorId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} | Cpf: {Cpf}";
        }
    }
}
