using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MatriculaWPF.Models
{
    [Table("Mentores")]
    class Mentor : Pessoa
    {
        public override string ToString()
        {
            return $"{Nome} - {Cpf}";
        }
    }
}
