using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class DiaDAO
    {
        private readonly Context _context;
        public DiaDAO(Context context) => _context = context;
        public bool Cadastrar(Dia d)
        {
            if (BuscarDiaPorDescricao(d.Descricao) == null)
            {
                _context.Dias.Add(d);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Dia> Listar() => _context.Dias.ToList();
        public Dia BuscarDiaPorDescricao(string descricao) => _context.Dias.Where(d => d.Descricao == descricao)
                    .FirstOrDefault();
        public Dia BuscarDiaPorOrdenacao(int ordenacao) => _context.Dias.Where(d => d.Ordenacao == ordenacao)
                    .FirstOrDefault();
        public Dia BuscarDiaPorId(int id) => _context.Dias.Where(d => d.Id == id)
                    .FirstOrDefault();
        public void Alterar(Dia dia)
        {
            _context.Dias.Update(dia);
            _context.SaveChanges();
        }
        public Dia BuscarPorId(int id) => _context.Dias.Find(id);
        public void Remover(int id)
        {
            _context.Dias.Remove(_context.Dias.Find(id));
            _context.SaveChanges();
        }
    }
}
