using MatriculaWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.DAL
{
    public class MentorDisciplinaDAO
    {
        private readonly Context _context;
        public MentorDisciplinaDAO(Context context) => _context = context;
        public bool Cadastrar(MentorDisciplina mentordisciplina)
        {
            if (BuscarMentorDisciplina(mentordisciplina) == null)
            {
                _context.MentorDisciplinas.Add(mentordisciplina);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<MentorDisciplina> Listar() => _context.MentorDisciplinas.Include(d => d.Disciplina).Include(m => m.Mentor).ToList();
        public MentorDisciplina BuscarMentorDisciplina(MentorDisciplina mentordisciplina) => _context.MentorDisciplinas.Where(md => md.Disciplina == mentordisciplina.Disciplina && md.Mentor == mentordisciplina.Mentor)
                    .FirstOrDefault();
        public MentorDisciplina BuscarMentorDisciplinaPorId(int id) => _context.MentorDisciplinas.Where(md => md.Id == id)
                    .FirstOrDefault();
        public List<MentorDisciplina> ListarMentoresDisciplinasPorMentor(Mentor mentor) => _context.MentorDisciplinas
            .Include(m => m.Mentor)
            .Include(d => d.Disciplina)
            .Where(md => md.MentorId == mentor.Id)
            .ToList();
        //public static MentorDisciplina BuscarConteudosMentorDisciplina(int id)
        //{

        //}
        public void Alterar(MentorDisciplina mentordisciplina)
        {
            _context.MentorDisciplinas.Update(mentordisciplina);
            _context.SaveChanges();
        }
        public void Remover(int id)
        {
            _context.MentorDisciplinas.Remove(_context.MentorDisciplinas.Find(id));
            _context.SaveChanges();
        }
        public MentorDisciplina BuscarPorId(int id) => _context.MentorDisciplinas.Find(id);
    }
}
