using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class AlunoDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Aluno n)
        {
            if (BuscarAlunoPorCpf(n.Cpf) == null)
            {
                _context.Alunos.Add(n);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void Remover(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }
        public static void Alterar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }
        public static List<Aluno> Listar() => _context.Alunos.ToList();
        public static Aluno BuscarAlunoPorCpf(string cpf) => _context.Alunos.Where(a => a.Cpf == cpf)
                    .FirstOrDefault();
        public static Aluno BuscarAlunoPorId(int id) => _context.Alunos.Where(a => a.Id == id)
                    .FirstOrDefault();
    }
}
