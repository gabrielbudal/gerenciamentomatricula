using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Mentor : Pessoa
    {
        public override string ToString()
        {
            return $"{Nome} - {Cpf}";
        }
    }
}
