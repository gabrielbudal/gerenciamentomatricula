using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MatriculaWPF.Models
{
    [Table("Alunos")]
    class Aluno : Pessoa
    {
        public override string ToString()
        {
            return $"Nome: {Nome} | Cpf: {Cpf}";
        }
    }
}
