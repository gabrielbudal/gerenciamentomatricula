using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaWPF.Models
{
    class Presenca : BaseModel
    {
        //Contrutores
        public Presenca()
        {
            ConjuntoAluno = new ConjuntoAluno();
            Grade = new Grade();
            Data = DateTime.Now;
        }
        //Atributos, propriedades e características
        public ConjuntoAluno ConjuntoAluno { get; set; }
        public Grade Grade { get; set; }
        public DateTime Data { get; set; }
        public Boolean Presente { get; set; }
    }
}
