using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class NivelDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Nivel n)
        {
            if (BuscarNivelPorNome(n.Nome) == null)
            {
                _context.Niveis.Add(n);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void Remover(Nivel nivel)
        {
            _context.Niveis.Remove(nivel);
            _context.SaveChanges();
        }
        public static void Alterar(Nivel nivel)
        {
            _context.Niveis.Update(nivel);
            _context.SaveChanges();
        }
        public static List<Nivel> Listar() => _context.Niveis.ToList();
        public static Nivel BuscarNivelPorNome(string nome) => _context.Niveis.Where(n => n.Nome == nome)
                    .FirstOrDefault();
        public static Nivel BuscarNivelPorId(int id) => _context.Niveis.Where(n => n.Id == id)
                    .FirstOrDefault();
    }
}
