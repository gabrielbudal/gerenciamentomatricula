using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class ConjuntoAlunoDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(ConjuntoAluno conjuntoaluno)
        {
            //_context.ChangeTracker.AutoDetectChangesEnabled = false;
            _context.ConjuntoAlunos.Add(conjuntoaluno);
            _context.SaveChanges();
            return true;
        }
        public static ConjuntoAluno BuscarConjuntoAluno(ConjuntoAluno conjuntoaluno) => _context.ConjuntoAlunos.Where(ca => ca.Turma == conjuntoaluno.Turma && ca.Aluno == conjuntoaluno.Aluno)
                    .FirstOrDefault();
    }
}
