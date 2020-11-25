using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class NivelDAO
    {
        private readonly Context _context;
        public NivelDAO(Context context) => _context = context;
        public bool Cadastrar(Nivel n)
        {
            if (BuscarNivelPorNome(n.Nome) == null)
            {
                _context.Niveis.Add(n);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.Niveis.Remove(_context.Niveis.Find(id));
            _context.SaveChanges();
        }
        public void Alterar(Nivel nivel)
        {
            _context.Niveis.Update(nivel);
            _context.SaveChanges();
        }
        public List<Nivel> Listar() => _context.Niveis.ToList();
        public Nivel BuscarNivelPorNome(string nome) => _context.Niveis.Where(n => n.Nome == nome)
                    .FirstOrDefault();
        public Nivel BuscarNivelPorId(int id) => _context.Niveis.Where(n => n.Id == id)
                    .FirstOrDefault();
        public Nivel BuscarNivelPorOrdenacao(int ordenacao) => _context.Niveis.Where(n => n.Ordenacao == ordenacao)
                    .FirstOrDefault();
        public Nivel BuscarPorId(int id) => _context.Niveis.Find(id);
    }
}
