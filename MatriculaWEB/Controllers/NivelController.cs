using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class NivelController : Controller
    {
        private readonly NivelDAO _nivelDAO;
        public NivelController(NivelDAO nivelDAO) => _nivelDAO = nivelDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Niveis";
            return View(_nivelDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                if (_nivelDAO.Cadastrar(nivel))
                {
                    return RedirectToAction("Index", "Nivel");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um aluno com este CPF!");
            }
            return View(nivel);
        }
        public IActionResult Remover(int id)
        {
            _nivelDAO.Remover(id);
            return RedirectToAction("Index", "Nivel");
        }
        public IActionResult Alterar(int id)
        {
            return View(_nivelDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                _nivelDAO.Alterar(nivel);
                return RedirectToAction("Index", "Nivel");
            }
            return View(nivel);
        }
    }
}
