using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class MentorDisciplina
    {
        public MentorDisciplina()
        {
            Mentor = new Mentor();
            Disciplina = new Disciplina();
        }
        //Atributos, propriedades e características
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
