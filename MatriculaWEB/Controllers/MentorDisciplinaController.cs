using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class MentorDisciplinaController : Controller
    {
        private readonly MentorDisciplinaDAO _mentordisciplinaDAO;
        public MentorDisciplinaController(MentorDisciplinaDAO mentordisciplinaDAO) => _mentordisciplinaDAO = mentordisciplinaDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de relacionamento Mentores x Disciplinas";
            return View(_mentordisciplinaDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(MentorDisciplina mentordisciplina)
        {
            if (ModelState.IsValid)
            {
                if (_mentordisciplinaDAO.Cadastrar(mentordisciplina))
                {
                    return RedirectToAction("Index", "MentorDisciplina");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um aluno com este CPF!");
            }
            return View(mentordisciplina);
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
