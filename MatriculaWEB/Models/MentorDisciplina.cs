using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class MentorDisciplina : BaseModel
    {
        public MentorDisciplina()
        {
            Mentor = new Mentor();
            Disciplina = new Disciplina();
        }
        //Atributos, propriedades e características
        //public string Descricao { get; set; }
        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }
        public override string ToString()
        {
            return Mentor.Nome + " (" + Mentor.Cpf + ") " + Disciplina.Nome;
        }
    }
}
