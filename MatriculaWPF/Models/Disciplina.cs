using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MatriculaWPF.Models
{
    [Table("Disciplinas")]
    class Disciplina : BaseModel
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
            return $"Nome: {Nome} | Descrição: {Descricao}";
        }
    }
}
