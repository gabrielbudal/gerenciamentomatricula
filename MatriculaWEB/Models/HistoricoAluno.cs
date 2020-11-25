using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class HistoricoAluno : BaseModel
    {
        //Contrutores
        public HistoricoAluno()
        {
            Aluno = new Aluno();
            Nivel = new Nivel();

        }
        //Atributos, propriedades e características
        public Aluno Aluno { get; set; }
        public Nivel Nivel { get; set; }
    }
}
