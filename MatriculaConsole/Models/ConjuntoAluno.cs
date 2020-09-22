using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class ConjuntoAluno
    {
        //Contrutores
        public ConjuntoAluno()
        {
        }
        //Atributos, propriedades e características
        public Aluno Aluno { get; set; }
        public Turma Turma { get; set; }
    }
}
