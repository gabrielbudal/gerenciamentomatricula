using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    [Table("Disciplinas")]
    class Disciplina
    {
        //Contrutores
        public Disciplina(//string nome, string descricao
            )
        {
            //Nome = nome;
            //Descricao = Descricao;
        }
        //Atributos, propriedades e características
        [Key]
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} | Descrição: {Descricao}";
        }
    }
}
