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
        public string HoraFim { get; set; }
        public string HoraInicio { get; set; }
        public int TotalAulas { get; set; }
        public override string ToString()
        {
            return $"Horário de início: {HoraInicio} | Horário fim: {HoraFim}" +
                $" | Total de aulas: {TotalAulas}";
        }
    }
}
