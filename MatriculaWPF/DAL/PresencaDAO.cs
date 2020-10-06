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
                _context.Presencas.Add(presenca);
                _context.SaveChanges();
                return true;
        }
        public static List<Presenca> ListarPresencasHoje(string dia, DateTime data) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(d => d.Dia)
            .Where(g => g.Grade.Dia.Descricao == dia && g.CriadoEm.Month == data.Month && g.CriadoEm.Day == data.Day)
            .ToList();
        public static List<Presenca> ListarPresencasPorGrade(int id) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(t => t.Turma)
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(a => a.Aluno)
            .Where(g => g.Grade.Id == id)
            .ToList();
    }
}
