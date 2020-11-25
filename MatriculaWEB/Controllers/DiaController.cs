using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class DiaController : Controller
    {
        private readonly DiaDAO _diaDAO;
        public DiaController(DiaDAO diaDAO) => _diaDAO = diaDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Dias";
            return View(_diaDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Dia dia)
        {
            if (ModelState.IsValid)
            {
                _diaDAO.Cadastrar(dia);
                return RedirectToAction("Index", "Dia");
            }
            return View(dia);
        }
        public IActionResult Remover(int id)
        {
            _diaDAO.Remover(id);
            return RedirectToAction("Index", "Dia");
        }
        public IActionResult Alterar(int id)
        {
            return View(_diaDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Dia dia)
        {
            if (ModelState.IsValid)
            {
                _diaDAO.Alterar(dia);
                return RedirectToAction("Index", "Dia");
            }
            return View(dia);
        }
    }
}
