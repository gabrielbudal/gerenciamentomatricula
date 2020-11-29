using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Grade : BaseModel
    {
        //Contrutores
        public Grade()
        {
            Turma = new Turma();
            MentorDisciplina = new MentorDisciplina();
            Dia = new Dia();
            //Descricao = "Turma: " + Turma.Descricao + " " + MentorDisciplina.Descricao + HorarioInicio + " " + HorarioFim + " " + Dia;
        }
        //Atributos, propriedades e características
        [ForeignKey("TurmaId")]
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        [ForeignKey("MentorDisciplinaId")]
        public MentorDisciplina MentorDisciplina { get; set; }
        public int MentorDisciplinaId { get; set; }
        [ForeignKey("DiaId")]
        public Dia Dia { get; set; }
        public int DiaId { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
        //public string Descricao { get; set; }
        public override string ToString()
        {
            return "Dia:" + Dia.Descricao + "Horário de Início: " + HorarioInicio + " - Horário de Fim: " + HorarioFim + " " + Turma.Nivel.Nome + " ";
        }
    }
}
