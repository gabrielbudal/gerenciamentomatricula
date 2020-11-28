using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class AdministracaoHorarioDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(AdministracaoHorario a)
        {
            _context.AdministracaoHorarios.Add(a);
            _context.SaveChanges();
            return true;
        }
        public static void Remover(AdministracaoHorario a)
        {
            _context.AdministracaoHorarios.Remove(a);
            _context.SaveChanges();
        }
        public static void Alterar(AdministracaoHorario a)
        {
            _context.AdministracaoHorarios.Update(a);
            _context.SaveChanges();
        }
        public static List<AdministracaoHorario> Listar() => _context.AdministracaoHorarios.ToList();
        public static AdministracaoHorario BuscarAdmPorId(int id) => _context.AdministracaoHorarios.Where(a => a.Id == id)
                    .FirstOrDefault();
    }
}
