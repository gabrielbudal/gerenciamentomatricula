using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class Grade
    {
        //Contrutores
        public Grade()
        {
            Turma = new Turma();
            MentorDisciplina = new MentorDisciplina();
            Dia = new Dia();
            Nivel = new Nivel();
        }
        //Atributos, propriedades e características
        public Turma Turma { get; set; }
        public MentorDisciplina MentorDisciplina { get; set; }
        public Dia Dia { get; set; }
        public Nivel Nivel { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
    }
}
