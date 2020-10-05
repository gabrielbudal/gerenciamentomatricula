using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaWPF.Models
{
    class Grade : BaseModel
    {
        //Contrutores
        public Grade()
        {
            Turma = new Turma();
            MentorDisciplina = new MentorDisciplina();
            Dia = new Dia();
        }
        //Atributos, propriedades e características
        public Turma Turma { get; set; }
        public MentorDisciplina MentorDisciplina { get; set; }
        public Dia Dia { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
    }
}
