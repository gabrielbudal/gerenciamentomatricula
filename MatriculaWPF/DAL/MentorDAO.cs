using MatriculaWPF.Models;
using MatriculaWPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class MentorDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Mentor m)
        {
                if (BuscarMentorPorCpf(m.Cpf) == null)
                {
                    _context.Mentores.Add(m);
                    _context.SaveChanges();
                    return true;
                }
                return false;
        }
        public static List<Mentor> Listar() => _context.Mentores.ToList();
        public static Mentor BuscarMentorPorCpf(string cpf) => _context.Mentores.Where(m => m.Cpf == cpf)
                    .FirstOrDefault();
    }
}
