using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaWPF.Models
{
    class Turma : BaseModel
    {
        //Contrutores
        public Turma()
        {
            AdministracaoHorario = new AdministracaoHorario();
            Nivel = new Nivel();
            DateTime dataatual = DateTime.Now;
            Ano = dataatual.Year;
        }
        //Atributos, propriedades e características
        public string Descricao { get; set; }
        public AdministracaoHorario AdministracaoHorario { get; set; }
        public int Ano { get; set; }
        public Nivel Nivel { get; set; }
        public override string ToString()
        {
            return $"{Nivel} - {Descricao} - {Ano}";
        }
    }
}
