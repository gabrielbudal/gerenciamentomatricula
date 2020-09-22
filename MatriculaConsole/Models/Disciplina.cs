using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
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
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} | Descrição: {Descricao}";
        }
    }
}
