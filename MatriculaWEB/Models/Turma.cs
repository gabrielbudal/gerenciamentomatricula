using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Turma : BaseModel
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
        //public string Descricao { get; set; }
        [ForeignKey("AdministracaoHorarioId")]
        public AdministracaoHorario AdministracaoHorario { get; set; }
        public int Ano { get; set; }
        [ForeignKey("NivelId")]
        public Nivel Nivel { get; set; }
        public int AdministracaoHorarioId { get; set; }
        public int NivelId { get; set; }
        public override string ToString()
        {
            return $"{Nivel.Nome} - {Ano}";
        }

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
