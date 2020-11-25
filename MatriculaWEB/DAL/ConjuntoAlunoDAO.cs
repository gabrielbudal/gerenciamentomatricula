using MatriculaWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class ConjuntoAlunoDAO
    {
        private readonly Context _context;
        public ConjuntoAlunoDAO(Context context) => _context = context;
        public bool Cadastrar(ConjuntoAluno conjuntoaluno)
        {
            //_context.ChangeTracker.AutoDetectChangesEnabled = false;
            _context.ConjuntoAlunos.Add(conjuntoaluno);
            _context.SaveChanges();
            return true;
        }
        public List<ConjuntoAluno> Listar() => _context.ConjuntoAlunos.Include(a => a.Aluno).ToList();
        //public static ConjuntoAluno BuscarConjuntoAluno(ConjuntoAluno conjuntoaluno) => _context.ConjuntoAlunos.Where(ca => ca.Turma == conjuntoaluno.Turma && ca.Aluno == conjuntoaluno.Aluno)
        //           .FirstOrDefault();
        public List<ConjuntoAluno> BuscarConjuntoAlunoPorTurma(ConjuntoAluno conjuntoaluno) => _context.ConjuntoAlunos.Include(a => a.Aluno).Where(ca => ca.Turma == conjuntoaluno.Turma)
                   .ToList();
        public List<ConjuntoAluno> BuscarConjuntoAlunoPorIdTurma(int idturma) => _context.ConjuntoAlunos.Include(a => a.Aluno).Where(ca => ca.Turma.Id == idturma)
                   .ToList();
        public ConjuntoAluno BuscarConjuntoAlunoPorId(int idconjuntoaluno) => _context.ConjuntoAlunos.Where(ca => ca.Id == idconjuntoaluno)
                   .FirstOrDefault();
        public ConjuntoAluno BuscarConjuntoAlunoPorIdTabelas(int idconjuntoaluno) => _context.ConjuntoAlunos.Where(ca => ca.Id == idconjuntoaluno)
                   .FirstOrDefault();

        public ConjuntoAluno BuscarConjuntoAlunoPorIdTabelas() => _context.ConjuntoAlunos
            .Include(a => a.Aluno)
            .FirstOrDefault();
        public void Alterar(ConjuntoAluno conjuntoaluno)
        {
            _context.ConjuntoAlunos.Update(conjuntoaluno);
            _context.SaveChanges();
        }
        public ConjuntoAluno BuscarPorId(int id) => _context.ConjuntoAlunos.Find(id);
    }
}
