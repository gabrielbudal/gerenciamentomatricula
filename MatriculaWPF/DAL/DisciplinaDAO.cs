using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class DisciplinaDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Disciplina d)
        {
            if (BuscarDisciplinaPorNome(d.Nome) == null)
            {
                _context.Disciplinas.Add(d);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static Disciplina BuscarDisciplinaPorNome(string nome) => _context.Disciplinas.Where(d => d.Nome == nome)
                    .FirstOrDefault();
        public static List<Disciplina> Listar() => _context.Disciplinas.ToList();
    }
}
