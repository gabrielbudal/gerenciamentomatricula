using MatriculaWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class ChatDAO
    {
        private readonly Context _context;
        public ChatDAO(Context context) => _context = context;

        public List<Chat> Listar() => _context.Chats.ToList();
        public List<Chat> ListarPorTurma(int Id) => _context.Chats
            .Include(c => c.Turma)
            .Where(c => c.Turma.Id == Id)
            .ToList();
        public bool Cadastrar(Chat chat)
        {
            _context.Chats.Add(chat);
            _context.SaveChanges();
            return true;
        }
    }
}
