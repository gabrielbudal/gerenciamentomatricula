using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class TurmaController : Controller
    {
        private readonly TurmaDAO _turmaDAO;
        public TurmaController(TurmaDAO turmaDAO) => _turmaDAO = turmaDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Turmas";
            return View(_turmaDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Turma turma)
        {
            if (ModelState.IsValid)
            {
                if (_turmaDAO.Cadastrar(turma))
                {
                    return RedirectToAction("Index", "Turma");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe uma turma com este nome!");
            }
            return View(turma);
        }
        public IActionResult Remover(int id)
        {
            _turmaDAO.Remover(id);
            return RedirectToAction("Index", "Turma");
        }
        public IActionResult Alterar(int id)
        {
            return View(_turmaDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Turma turma)
        {
            if (ModelState.IsValid)
            {
                _turmaDAO.Alterar(turma);
                return RedirectToAction("Index", "Turma");
            }
            return View(turma);
        }
    }
}
