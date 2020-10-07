using MatriculaWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class PresencaDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Presenca presenca)
        {
            //DateTime dataatual = DateTime.Now.AddDays(+14);
            DateTime dataatual = DateTime.Now;
            if (BuscarPresencasExistentes(presenca, dataatual) == null)
            { 
                _context.Presencas.Add(presenca);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Presenca> ListarPresencasHoje(string dia, DateTime data) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(d => d.Dia)
            .Where(g => g.Grade.Dia.Descricao == dia && g.CriadoEm.Month == data.Month && g.CriadoEm.Day == data.Day
                && g.CriadoEm.Year == data.Year)
                    .ToList();
        public static List<Presenca> ListarPresencasPorGrade(int id) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(t => t.Turma)
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(a => a.Aluno)
            .Where(g => g.Grade.Id == id)
            .ToList();
        public static List<Presenca> ListarPresencasPorListaGrade(List<Grade> grades) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(t => t.Turma)
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(a => a.Aluno)
            .Where(p => grades.Contains(p.Grade))
            .ToList();
        public static Presenca BuscarPresencasExistentes(Presenca presenca, DateTime data) => _context.Presencas
            .Where(pa => pa.ConjuntoAluno == presenca.ConjuntoAluno 
                && pa.Grade == presenca.Grade && pa.CriadoEm.Month == data.Month && pa.CriadoEm.Day == data.Day
                    && pa.CriadoEm.Year == data.Year)
                        .FirstOrDefault();
    }
}
