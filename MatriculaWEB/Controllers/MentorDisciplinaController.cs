using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatriculaWEB.Controllers
{
    public class MentorDisciplinaController : Controller
    {
        private readonly MentorDisciplinaDAO _mentordisciplinaDAO;
        private readonly MentorDAO _mentorDAO;
        private readonly DisciplinaDAO _disciplinaDAO;
        public MentorDisciplinaController(MentorDisciplinaDAO mentordisciplinaDAO, 
            MentorDAO mentorDAO,
            DisciplinaDAO disciplinaDAO)
        {
            _mentordisciplinaDAO = mentordisciplinaDAO;
            _mentorDAO = mentorDAO;
            _disciplinaDAO = disciplinaDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de relacionamento Mentores x Disciplinas";
            return View(_mentordisciplinaDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.Mentores = new SelectList(_mentorDAO.Listar(), "Id", "Nome");
            ViewBag.Disciplinas = new SelectList(_disciplinaDAO.Listar(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(MentorDisciplina mentordisciplina)
        {
            mentordisciplina.Mentor = _mentorDAO.BuscarPorId(mentordisciplina.MentorId);
            mentordisciplina.Disciplina = _disciplinaDAO.BuscarPorId(mentordisciplina.DisciplinaId);
            //if (ModelState.IsValid)
            //{
                _mentordisciplinaDAO.Cadastrar(mentordisciplina);
                return RedirectToAction("Index", "MentorDisciplina");
            //}
            //ViewBag.Mentores = new SelectList(_mentorDAO.Listar(), "Id", "Nome");
            //ViewBag.Disciplinas = new SelectList(_disciplinaDAO.Listar(), "Id", "Nome");
            //return View(mentordisciplina);
        }
        public IActionResult Remover(int id)
        {
            _mentordisciplinaDAO.Remover(id);
            return RedirectToAction("Index", "MentorDisciplina");
        }
        public IActionResult Alterar(int id)
        {
            return View(_mentordisciplinaDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(MentorDisciplina mentordisciplina)
        {
            if (ModelState.IsValid)
            {
                _mentordisciplinaDAO.Alterar(mentordisciplina);
                return RedirectToAction("Index", "MentorDisciplina");
            }
            return View(mentordisciplina);
        }
    }
}
