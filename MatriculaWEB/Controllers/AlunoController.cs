using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using MatriculaWEB.Models;
using System.Linq;
using MatriculaWEB.DAL;

namespace MatriculaWEB.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AlunoDAO _alunoDAO;
        public AlunoController(AlunoDAO alunoDAO) => _alunoDAO = alunoDAO;
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Alunos";
            return View(_alunoDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                if (_alunoDAO.Cadastrar(aluno))
                {
                    return RedirectToAction("Index", "Aluno");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um aluno com este CPF!");      
            }
            return View(aluno);
        }
        public IActionResult Remover(int id)
        {
            _alunoDAO.Remover(id);
            return RedirectToAction("Index", "Aluno");
        }
        public IActionResult Alterar(int id)
        {
            return View(_alunoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoDAO.Alterar(aluno);
                return RedirectToAction("Index", "Aluno");
            }
            return View(aluno);
        }
    }
}
