using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Disciplina : BaseModel
    {
        //Contrutores
        public Disciplina(//string nome, string descricao
            )
        {
            //Nome = nome;
            //Descricao = Descricao;
        }
        //Atributos, propriedades e características
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public override string ToString()
        {
            return $"{Nome} - {Descricao}";
        }
    }
}
