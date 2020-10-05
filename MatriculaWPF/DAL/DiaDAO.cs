using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class DiaDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(Dia d)
        {
            if (BuscarDiaPorDescricao(d.Descricao) == null)
            {
                _context.Dias.Add(d);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<Dia> Listar() => _context.Dias.ToList();
        public static Dia BuscarDiaPorDescricao(string descricao) => _context.Dias.Where(d => d.Descricao == descricao)
                    .FirstOrDefault();
        public static Dia BuscarDiaPorOrdenacao(int ordenacao) => _context.Dias.Where(d => d.Ordenacao == ordenacao)
                    .FirstOrDefault();
        public static Dia BuscarDiaPorId(int id) => _context.Dias.Where(d => d.Id == id)
                    .FirstOrDefault();
    }
}
