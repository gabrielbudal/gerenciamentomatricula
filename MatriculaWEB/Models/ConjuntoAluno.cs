using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class ConjuntoAluno : BaseModel
    {
        //Contrutores
        public ConjuntoAluno()
        {
            Turma = new Turma();
            Aluno = new Aluno();
            //Descricao = "Turma " + Turma.Descricao;
            //Alunos = new List<Aluno>();
        }
        //Atributos, propriedades e características
        public Turma Turma { get; set; }
        public Aluno Aluno { get; set; }
        //public string Descricao { get; set; }
        //public List<Aluno> Alunos { get; set; }
        public override string ToString()
        {
            return Aluno.Nome + " (" + Aluno.Cpf + ")";
        }
    }
}
