using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Chat : BaseModel
    {
        public Chat(//string nome, string descricao
            )
        {
            //Nome = nome;
            //Descricao = Descricao;
        }
        public string Mensagem { get; set; }
        public override string ToString()
        {
            return $"{Mensagem}";
            //nome usuario
        }
    }
}
