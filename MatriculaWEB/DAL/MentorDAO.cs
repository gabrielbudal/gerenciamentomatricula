using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class MentorDAO
    {
        private readonly Context _context;
        public MentorDAO(Context context) => _context = context;
        public bool Cadastrar(Mentor m)
        {
            if (BuscarMentorPorCpf(m.Cpf) == null)
            {
                _context.Mentores.Add(m);
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
        public void Alterar(Mentor mentor)
        {
            _context.Mentores.Update(mentor);
            _context.SaveChanges();
        }
        public List<Mentor> Listar() => _context.Mentores.ToList();
        public Mentor BuscarMentorPorCpf(string cpf) => _context.Mentores.Where(m => m.Cpf == cpf)
                    .FirstOrDefault();
        public Mentor BuscarMentorPorId(int id) => _context.Mentores.Where(m => m.Id == id)
                    .FirstOrDefault();
        public Mentor BuscarPorId(int id) => _context.Mentores.Find(id);
    }
}
