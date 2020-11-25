using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class AdministracaoHorarioController : Controller
    {
        private readonly AdministracaoHorarioDAO _administracaohorarioDAO;
        public AdministracaoHorarioController(AdministracaoHorarioDAO administracaohorarioDAO) => _administracaohorarioDAO = administracaohorarioDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de administração de horários";
            return View(_administracaohorarioDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(AdministracaoHorario administracaohorario)
        {
            _administracaohorarioDAO.Cadastrar(administracaohorario);
            return RedirectToAction("Index", "AdministracaoHorario");
        }
        public IActionResult Remover(int id)
        {
            _administracaohorarioDAO.Remover(id);
            return RedirectToAction("Index", "AdministracaoHorario");
        }
        public IActionResult Alterar(int id)
        {
            return View(_administracaohorarioDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(AdministracaoHorario administracaohorario)
        {
            if (ModelState.IsValid)
            {
                _administracaohorarioDAO.Alterar(administracaohorario);
                return RedirectToAction("Index", "AdministracaoHorario");
            }
            return View(administracaohorario);
        }
    }
}
