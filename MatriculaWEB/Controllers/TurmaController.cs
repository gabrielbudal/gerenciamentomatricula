using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatriculaWEB.Controllers
{
    public class TurmaController : Controller
    {
        private readonly TurmaDAO _turmaDAO;
        private readonly NivelDAO _nivelDAO;
        private readonly AdministracaoHorarioDAO _administracaohorarioDAO;
        public TurmaController(TurmaDAO turmaDAO,
            NivelDAO nivelDAO,
            AdministracaoHorarioDAO administracaohorarioDAO)
        {
            _turmaDAO = turmaDAO;
            _nivelDAO = nivelDAO;
            _administracaohorarioDAO = administracaohorarioDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Turmas";
            return View(_turmaDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.AdministracaoHorarios = new SelectList(_administracaohorarioDAO.Listar(), "Id", "TotalAulas");
            ViewBag.Niveis = new SelectList(_nivelDAO.Listar(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Turma turma)
        {
            //if (ModelState.IsValid)
            //{
            //if (_turmaDAO.Cadastrar(turma))
            //{
            turma.AdministracaoHorario = _administracaohorarioDAO.BuscarPorId(turma.AdministracaoHorarioId);
            turma.Nivel = _nivelDAO.BuscarPorId(turma.NivelId);
            _turmaDAO.Cadastrar(turma);
                    return RedirectToAction("Index", "Turma");
                //}
                //ModelState.AddModelError("", "Não foi possível cadastrar pois já existe uma turma com este nome!");
            //}
            //return View(turma);
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
