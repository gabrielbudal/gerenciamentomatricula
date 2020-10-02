using System;
using System.Collections.Generic;
using System.Text;

namespace MatriculaWPF.Models
{
    class AdministracaoHorario : BaseModel
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
