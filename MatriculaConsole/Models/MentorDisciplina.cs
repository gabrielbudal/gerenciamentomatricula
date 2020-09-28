using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    [Table("MentorDisciplinas")]
    class MentorDisciplina
    {
        public MentorDisciplina()
        {
            Mentor = new Mentor();
            Disciplina = new Disciplina();
        }
        //Atributos, propriedades e características
        [Key]
        public int MentorDisciplinasId { get; set; }
        public Mentor Mentor { get; set; }
        public Disciplina Disciplina { get; set; }
        public Boolean Ativo { get; set; }
        public override string ToString()
        {
            Console.WriteLine("Relação mentor e disciplina: ");
            return $"Mentor = {Mentor} \nDisciplina = {Disciplina}\n\n";
        }
    }
}
