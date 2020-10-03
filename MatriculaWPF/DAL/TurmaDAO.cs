using MatriculaWPF.Models;
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
        public static List<Turma> Listar() => _context.Turmas.ToList();
        public static Turma BuscarTurma(Turma turma) => _context.Turmas.Where(t => t.AdministracaoHorario == turma.AdministracaoHorario && t.Nivel == turma.Nivel)
                    .FirstOrDefault();
    }
}
