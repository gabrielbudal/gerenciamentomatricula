using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MatriculaWPF.Models
{
    [Table("MentorDisciplinas")]
    class MentorDisciplina : BaseModel
    {
        public MentorDisciplina()
        {
            Mentor = new Mentor();
            Disciplina = new Disciplina();
        }
        //Atributos, propriedades e características
        public Mentor Mentor { get; set; }
        public Disciplina Disciplina { get; set; }
        public override string ToString()
        {
            Console.WriteLine("Relação mentor e disciplina: ");
            return $"Mentor = {Mentor} \nDisciplina = {Disciplina}\n\n";
        }
    }
}
