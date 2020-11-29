using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Presenca : BaseModel
    {
        //Contrutores
        public Presenca()
        {
            ConjuntoAluno = new ConjuntoAluno();
            Grade = new Grade();
            //Aluno = new Aluno();
            //Data = DateTime.Now;
        }
        //Atributos, propriedades e características
        [ForeignKey("ConjuntoAlunoId")]
        public ConjuntoAluno ConjuntoAluno { get; set; }
        public int ConjuntoAlunoId { get; set; }
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }
        public int GradeId { get; set; }
        //public Aluno Aluno { get; set; }
        //public DateTime Data { get; set; }
        public Boolean Presente { get; set; }
    }
}
