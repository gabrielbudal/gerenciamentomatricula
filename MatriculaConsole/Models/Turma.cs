using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class Turma
    {
        //Contrutores
        public Turma()
        {
            AdministracaoHorario = new AdministracaoHorario();
            Nivel = new Nivel();
        }
        //Atributos, propriedades e características
        public string Descricao { get; set; }
        public AdministracaoHorario AdministracaoHorario { get; set; }
        public DateTime Data { get; set; }
        public Nivel Nivel { get; set; }
    }
}
