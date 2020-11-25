using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class GradeController : Controller
    {
        private readonly GradeDAO _gradeDAO;
        public GradeController(GradeDAO gradeDAO) => _gradeDAO = gradeDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Grades";
            return View(_gradeDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Grade grade)
        {
            if (ModelState.IsValid)
            {
                if (_gradeDAO.Cadastrar(grade))
                {
                    return RedirectToAction("Index", "Grade");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um aluno com este CPF!");
            }
            return View(grade);
        }
        public IActionResult Remover(int id)
        {
            _gradeDAO.Remover(id);
            return RedirectToAction("Index", "Grade");
        }
        public IActionResult Alterar(int id)
        {
            return View(_gradeDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeDAO.Alterar(grade);
                return RedirectToAction("Index", "Grade");
            }
            return View(grade);
        }
    }
}
