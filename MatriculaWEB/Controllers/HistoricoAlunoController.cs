using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class HistoricoAlunoController : Controller
    {
        private readonly HistoricoAlunoDAO _historicoalunoDAO;
        public HistoricoAlunoController(HistoricoAlunoDAO historicoalunoDAO) => _historicoalunoDAO = historicoalunoDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Historico de Alunos";
            return View(_historicoalunoDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(HistoricoAluno historicoaluno)
        {
            if (ModelState.IsValid)
            {
                if (_historicoalunoDAO.Cadastrar(historicoaluno))
                {
                    return RedirectToAction("Index", "HistoricoAluno");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um aluno com este CPF!");
            }
            return View(historicoaluno);
        }
        public IActionResult Remover(int id)
        {
            _historicoalunoDAO.Remover(id);
            return RedirectToAction("Index", "HistoricoAluno");
        }
        public IActionResult Alterar(int id)
        {
            return View(_historicoalunoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(HistoricoAluno historicoaluno)
        {
            if (ModelState.IsValid)
            {
                _historicoalunoDAO.Alterar(historicoaluno);
                return RedirectToAction("Index", "HistoricoAluno");
            }
            return View(historicoaluno);
        }
    }
}
