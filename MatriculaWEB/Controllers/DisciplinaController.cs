using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly DisciplinaDAO _disciplinaDAO;
        public DisciplinaController(DisciplinaDAO disciplinaDAO) => _disciplinaDAO = disciplinaDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Disciplinas";
            return View(_disciplinaDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                if (_disciplinaDAO.Cadastrar(disciplina))
                {
                    return RedirectToAction("Index", "Disciplina");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe uma disciplina com este nome!");
            }
            return View(disciplina);
        }
        public IActionResult Remover(int id)
        {
            _disciplinaDAO.Remover(id);
            return RedirectToAction("Index", "Disciplina");
        }
        public IActionResult Alterar(int id)
        {
            return View(_disciplinaDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _disciplinaDAO.Alterar(disciplina);
                return RedirectToAction("Index", "Disciplina");
            }
            return View(disciplina);
        }
    }
}
