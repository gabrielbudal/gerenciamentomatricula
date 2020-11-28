using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    [Table("Alunos")]
    public class Aluno : Pessoa
    {
        public Aluno()
        {
            //    ConjuntoAluno = new ConjuntoAluno();
            //ConjuntoAlunos = new List<ConjuntoAluno>();
        }
        // public ConjuntoAluno ConjuntoAluno { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} | Cpf: {Cpf}";
        }
    }
}
