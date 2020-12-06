using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Chat : BaseModel
    {
        public Chat()
        {
            Turma = new Turma();
        }
        public string Mensagem { get; set; }
        public string Cpf { get; set; }

        [ForeignKey("TurmaId")]
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public override string ToString()
        {
            return $"{Mensagem}";
            //nome usuario
        }
    }
}
