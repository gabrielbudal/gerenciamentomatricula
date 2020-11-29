using MatriculaWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class GradeDAO
    {
        private readonly Context _context;
        public GradeDAO(Context context) => _context = context;
        public bool Cadastrar(Grade grade)
        {
            if (BuscarGrade(grade) == null)
            {
                _context.Grades.Add(grade);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Grade> Listar() => _context.Grades
            .Include(d => d.Dia)
            .Include(md => md.MentorDisciplina)
                .ThenInclude(m => m.Mentor)
            .Include(md => md.MentorDisciplina)
                .ThenInclude(d => d.Disciplina)
            .Include(t => t.Turma)
                .ThenInclude(n => n.Nivel)
            .ToList();
        public List<Grade> ListarGradeHoje(string dia) => _context.Grades
            .Include(d => d.Dia)
            .Include(m => m.MentorDisciplina)
                .ThenInclude(m => m.Mentor)
            .Include(m => m.MentorDisciplina)
                .ThenInclude(d => d.Disciplina)
            .Include(t => t.Turma)
                .ThenInclude(n => n.Nivel)
            .Where(g => g.Dia.Descricao == dia)
            .ToList();
        public Grade BuscarGrade(Grade grade) => _context.Grades.Where(g => g.Turma == grade.Turma && g.MentorDisciplina == grade.MentorDisciplina && g.Dia == grade.Dia && g.HorarioInicio == grade.HorarioInicio && g.HorarioFim == grade.HorarioFim)
                    .FirstOrDefault();
        public Grade BuscarGradePorId(int id) => _context.Grades.Include(t => t.Turma)
                    .Where(g => g.Id == id)
                    .FirstOrDefault();
        public List<Grade> ListarPorTurma(int id) => _context.Grades.Include(t => t.Turma)
                    .Where(g => g.Turma.Id == id)
                    .ToList();
        public void Alterar(Grade grade)
        {
            _context.Grades.Update(grade);
            _context.SaveChanges();
        }
        public Grade BuscarPorId(int id) => _context.Grades.Find(id);
        public void Remover(int id)
        {
            _context.Grades.Remove(_context.Grades.Find(id));
            _context.SaveChanges();
        }
    }
}
