using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaWPF.Models
{
    class ConjuntoAluno : BaseModel
    {
        //Contrutores
        public ConjuntoAluno()
        {
            Turma = new Turma();
            Aluno = new Aluno();
            //Alunos = new List<Aluno>();
        }
        //Atributos, propriedades e características
        public Turma Turma { get; set; }
        public Aluno Aluno { get; set; }
        //public List<Aluno> Alunos { get; set; }
    }
}
