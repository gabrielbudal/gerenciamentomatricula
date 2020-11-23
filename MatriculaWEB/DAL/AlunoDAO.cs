using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class AlunoDAO
    {
        private readonly Context _context;
        public AlunoDAO(Context context) => _context = context;

        public List<Aluno> Listar() => _context.Alunos.ToList();
        public Aluno BuscarPorId(int id) => _context.Alunos.Find(id);
        public Aluno BuscarPorCpf(string cpf) => _context.Alunos.FirstOrDefault(a => a.Cpf == cpf);
        public bool Cadastrar(Aluno aluno)
        {
            if(BuscarPorCpf(aluno.Cpf) == null) 
            { 
                _context.Alunos.Add(aluno);
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
        public void Alterar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }
    }
}
