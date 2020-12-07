using MatriculaWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class PresencaDAO
    {
        private readonly Context _context;
        public PresencaDAO(Context context) => _context = context;
        public bool Cadastrar(Presenca presenca)
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
        public List<Presenca> Listar() => _context.Presencas
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(t => t.Turma)
                    .ThenInclude(n => n.Nivel)
            .Include(g => g.Grade)
            .ToList();
        public List<Presenca> ListarPorAluno(string cpf) => _context.Presencas
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(t => t.Turma)
                    .ThenInclude(n => n.Nivel)
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(a => a.Aluno)
            .Include(g => g.Grade)
            .Where(p => p.ConjuntoAluno.Aluno.Cpf == cpf)
            .ToList();
        public List<Presenca> ListarPresencasHoje(string dia, DateTime data) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(d => d.Dia)
            .Where(g => g.Grade.Dia.Descricao == dia && g.CriadoEm.Month == data.Month && g.CriadoEm.Day == data.Day
                && g.CriadoEm.Year == data.Year)
                    .ToList();
        public List<Presenca> ListarPresencasPorGrade(int id) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(t => t.Turma)
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(a => a.Aluno)
            .Where(g => g.Grade.Id == id)
            .ToList();
        public List<Presenca> ListarPresencasPorListaGrade(List<Grade> grades) => _context.Presencas
            .Include(p => p.Grade)
                .ThenInclude(t => t.Turma)
            .Include(ca => ca.ConjuntoAluno)
                .ThenInclude(a => a.Aluno)
            .Where(p => grades.Contains(p.Grade))
            .ToList();
        public Presenca BuscarPresencasExistentes(Presenca presenca, DateTime data) => _context.Presencas
            .Where(pa => pa.ConjuntoAluno == presenca.ConjuntoAluno
                && pa.Grade == presenca.Grade && pa.CriadoEm.Month == data.Month && pa.CriadoEm.Day == data.Day
                    && pa.CriadoEm.Year == data.Year)
                        .FirstOrDefault();
        public void Alterar(Presenca presenca)
        {
            _context.Presencas.Update(presenca);
            _context.SaveChanges();
        }
        public Presenca BuscarPorId(int id) => _context.Presencas.Find(id);
        public void Remover(int id)
        {
            _context.Presencas.Remove(_context.Presencas.Find(id));
            _context.SaveChanges();
        }
    }
}
