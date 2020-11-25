using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class DisciplinaDAO
    {
        private readonly Context _context;
        public DisciplinaDAO(Context context) => _context = context;
        public bool Cadastrar(Disciplina d)
        {
            if (BuscarDisciplinaPorNome(d.Nome) == null)
            {
                _context.Disciplinas.Add(d);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.Alunos.Remove(_context.Alunos.Find(id));
            _context.SaveChanges();
        }
        public void Alterar(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            _context.SaveChanges();
        }
        public Disciplina BuscarDisciplinaPorNome(string nome) => _context.Disciplinas.Where(d => d.Nome == nome)
                    .FirstOrDefault();
        public List<Disciplina> Listar() => _context.Disciplinas.ToList();
        public Disciplina BuscarDisciplinaPorId(int id) => _context.Disciplinas.Where(d => d.Id == id)
                    .FirstOrDefault();
        public Disciplina BuscarPorId(int id) => _context.Disciplinas.Find(id);
    }
}
