using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class AdministracaoHorarioDAO
    {
        private readonly Context _context;
        public AdministracaoHorarioDAO(Context context) => _context = context;
        public AdministracaoHorario BuscarPorId(int id) => _context.AdministracaoHorarios.Find(id);
        public bool Cadastrar(AdministracaoHorario a)
        {
            _context.AdministracaoHorarios.Add(a);
            _context.SaveChanges();
            return true;
        }
        public void Remover(int id)
        {
            _context.AdministracaoHorarios.Remove(_context.AdministracaoHorarios.Find(id));
            _context.SaveChanges();
        }
        public void Alterar(AdministracaoHorario a)
        {
            _context.AdministracaoHorarios.Update(a);
            _context.SaveChanges();
        }
        public List<AdministracaoHorario> Listar() => _context.AdministracaoHorarios.ToList();
        public AdministracaoHorario BuscarAdmPorId(int id) => _context.AdministracaoHorarios.Where(a => a.Id == id)
                    .FirstOrDefault();
    }
}
