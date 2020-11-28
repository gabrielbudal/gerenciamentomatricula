using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class MentorController : Controller
    {
        private readonly MentorDAO _mentorDAO;
        public MentorController(MentorDAO mentorDAO) => _mentorDAO = mentorDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Mentor";
            return View(_mentorDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                if (_mentorDAO.Cadastrar(mentor))
                {
                    return RedirectToAction("Index", "Mentor");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um mentor com este CPF!");
            }
            return View(mentor);
        }
        public IActionResult Remover(int id)
        {
            _mentorDAO.Remover(id);
            return RedirectToAction("Index", "Mentor");
        }
        public IActionResult Alterar(int id)
        {
            return View(_mentorDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                _mentorDAO.Alterar(mentor);
                return RedirectToAction("Index", "Mentor");
            }
            return View(mentor);
        }
    }
}
