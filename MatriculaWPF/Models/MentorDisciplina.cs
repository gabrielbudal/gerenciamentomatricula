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
        public string Descricao { get; set; }
        public Mentor Mentor { get; set; }
        public Disciplina Disciplina { get; set; }
        public override string ToString()
        {
            return $"{Descricao}";
        }
    }
}
