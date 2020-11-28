using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class HistoricoAlunoDAO
    {
        private readonly Context _context;
        public HistoricoAlunoDAO(Context context) => _context = context;
        public bool Cadastrar(HistoricoAluno historicoaluno)
        {
            if (BuscarHistoricoAluno(historicoaluno) == null)
            {
                _context.HistoricoAlunos.Add(historicoaluno);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<HistoricoAluno> Listar() => _context.HistoricoAlunos.ToList();
        public HistoricoAluno BuscarHistoricoAluno(HistoricoAluno historicoaluno) => _context.HistoricoAlunos.Where(ha => ha.Nivel == historicoaluno.Nivel && ha.Aluno == historicoaluno.Aluno)
                    .FirstOrDefault();
        public void Alterar(HistoricoAluno historicoaluno)
        {
            _context.HistoricoAlunos.Update(historicoaluno);
            _context.SaveChanges();
        }
        public void Remover(int id)
        {
            _context.HistoricoAlunos.Remove(_context.HistoricoAlunos.Find(id));
            _context.SaveChanges();
        }
        public HistoricoAluno BuscarPorId(int id) => _context.HistoricoAlunos.Find(id);
    }
}
