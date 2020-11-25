using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class PresencaController : Controller
    {
        private readonly PresencaDAO _presencaDAO;
        public PresencaController(PresencaDAO presencaDAO) => _presencaDAO = presencaDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Presenças";
            return View(_presencaDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Presenca presenca)
        {
            if (ModelState.IsValid)
            {
                if (_presencaDAO.Cadastrar(presenca))
                {
                    return RedirectToAction("Index", "Presenca");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um aluno com este CPF!");
            }
            return View(presenca);
        }
        public IActionResult Remover(int id)
        {
            _presencaDAO.Remover(id);
            return RedirectToAction("Index", "Presenca");
        }
        public IActionResult Alterar(int id)
        {
            return View(_presencaDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Presenca presenca)
        {
            if (ModelState.IsValid)
            {
                _presencaDAO.Alterar(presenca);
                return RedirectToAction("Index", "Presenca");
            }
            return View(presenca);
        }
    }
}
