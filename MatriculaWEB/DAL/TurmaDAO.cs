using MatriculaWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class TurmaDAO
    {
        private readonly Context _context;
        public TurmaDAO(Context context) => _context = context;
        public bool Cadastrar(Turma turma)
        {
            if (BuscarTurma(turma) == null)
            {
                _context.Turmas.Add(turma);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Turma> Listar() => _context.Turmas.Include(n => n.Nivel).Include(a => a.AdministracaoHorario).ToList();
        public Turma BuscarTurma(Turma turma) => _context.Turmas.Include(n => n.Nivel).Where(t => t.AdministracaoHorario == turma.AdministracaoHorario && t.Nivel == turma.Nivel)
                    .FirstOrDefault();
        public Turma BuscarTurmaPorId(int id) => _context.Turmas.Where(t => t.Id == id)
                    .FirstOrDefault();
        public List<Grade> ListarGradeHojePorTurma(string dia) => _context.Grades
            .Include(d => d.Dia)
            .Include(t => t.Turma)
                .ThenInclude(n => n.Nivel)
            .Where(g => g.Dia.Descricao == dia)
            .ToList();
        public void Alterar(Turma turma)
        {
            _context.Turmas.Update(turma);
            _context.SaveChanges();
        }
        public void Remover(int id)
        {
            _context.Turmas.Remove(_context.Turmas.Find(id));
            _context.SaveChanges();
        }
        public Turma BuscarPorId(int id) => _context.Turmas.Find(id);
    }
}
