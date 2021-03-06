﻿using System;
using System.Collections.Generic;
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
            Data = DateTime.Now;
        }
        //Atributos, propriedades e características
        public ConjuntoAluno ConjuntoAluno { get; set; }
        public Grade Grade { get; set; }
        //public Aluno Aluno { get; set; }
        public DateTime Data { get; set; }
        public Boolean Presente { get; set; }
    }
}
