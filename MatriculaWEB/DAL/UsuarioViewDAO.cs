using MatriculaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class UsuarioViewDAO
    {
        private readonly Context _context;
        public UsuarioViewDAO(Context context) => _context = context;
        public List<UsuarioView> Listar() => _context.Usuarios.ToList();
        public UsuarioView BuscarPorCpf(string cpf) => _context.Usuarios.FirstOrDefault(u => u.Cpf == cpf);
    }
}
