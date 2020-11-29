using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("TurmaId")]
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        //public string Descricao { get; set; }
        //public List<Aluno> Alunos { get; set; }
        public override string ToString()
        {
            return Aluno.Nome + " (" + Aluno.Cpf + ")";
        }
    }
}
