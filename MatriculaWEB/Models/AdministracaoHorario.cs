using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class AdministracaoHorario : BaseModel
    {
        //Contrutores
        public AdministracaoHorario()
        {
        }
        //Atributos, propriedades e características
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string HoraFim { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string HoraInicio { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int TotalAulas { get; set; }
        public override string ToString()
        {
            return $"Horário de início: {HoraInicio} | Horário fim: {HoraFim}" +
                $" | Total de aulas: {TotalAulas}";
        }
    }
}
