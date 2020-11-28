using MatriculaWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class TurmaDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Turma turma)
        {
            if (BuscarTurma(turma) == null)
            {
                _context.Turmas.Add(turma);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<Turma> Listar() => _context.Turmas.Include(n => n.Nivel).ToList();
        public static Turma BuscarTurma(Turma turma) => _context.Turmas.Include(n => n.Nivel).Where(t => t.AdministracaoHorario == turma.AdministracaoHorario && t.Nivel == turma.Nivel)
                    .FirstOrDefault();
        public static Turma BuscarTurmaPorId(int id) => _context.Turmas.Where(t => t.Id == id)
                    .FirstOrDefault();
        public static List<Grade> ListarGradeHojePorTurma(string dia) => _context.Grades
            .Include(d => d.Dia)
            .Include(t => t.Turma)
                .ThenInclude(n => n.Nivel)
            .Where(g => g.Dia.Descricao == dia)
            .ToList();
    }
}
