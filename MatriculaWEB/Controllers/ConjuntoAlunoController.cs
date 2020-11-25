using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class ConjuntoAlunoController : Controller
    {
        private readonly ConjuntoAlunoDAO _conjuntoalunoDAO;
        public ConjuntoAlunoController(ConjuntoAlunoDAO conjuntoalunoDAO) => _conjuntoalunoDAO = conjuntoalunoDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Conjunto de alunos";
            return View(_conjuntoalunoDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(ConjuntoAluno conjuntoaluno)
        {
            if (ModelState.IsValid)
            {
                _conjuntoalunoDAO.Cadastrar(conjuntoaluno);
                return RedirectToAction("Index", "ConjuntoAluno");
            }
            return View(conjuntoaluno);
        }
        public IActionResult Alterar(int id)
        {
            return View(_conjuntoalunoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(ConjuntoAluno conjuntoaluno)
        {
            if (ModelState.IsValid)
            {
                _conjuntoalunoDAO.Alterar(conjuntoaluno);
                return RedirectToAction("Index", "ConjuntoAluno");
            }
            return View(conjuntoaluno);
        }
    }
}
