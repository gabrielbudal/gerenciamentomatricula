using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.MatriculaConsole.Models
{
    class AdministracaoHorario
    {
        //Contrutores
        public AdministracaoHorario()
        {
        }
        //Atributos, propriedades e características
        public DateTime HoraFim { get; set; }
        public DateTime HoraInicio { get; set; }
        public int TotalAulas { get; set; }
    }
}
