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
    public class GradeController : Controller
    {
        private readonly GradeDAO _gradeDAO;
        private readonly TurmaDAO _turmaDAO;
        private readonly MentorDisciplinaDAO _mentordisciplinaDAO;
        private readonly DiaDAO _diaDAO;
        public GradeController(GradeDAO gradeDAO,
            TurmaDAO turmaDAO,
            MentorDisciplinaDAO mentordisciplinaDAO,
            DiaDAO diaDAO)
        {
            _gradeDAO = gradeDAO;
            _turmaDAO = turmaDAO;
            _mentordisciplinaDAO = mentordisciplinaDAO;
            _diaDAO = diaDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Grades";
            return View(_gradeDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.Turmas = new SelectList(_turmaDAO.Listar(), "Id", "Nivel");
            ViewBag.MentorDisciplinas = new SelectList(_mentordisciplinaDAO.Listar(), "Id", "Mentor", "Disciplina");
            ViewBag.Dias = new SelectList(_diaDAO.Listar(), "Id", "Descricao");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Grade grade)
        {
            grade.Turma = _turmaDAO.BuscarPorId(grade.TurmaId);
            grade.MentorDisciplina = _mentordisciplinaDAO.BuscarPorId(grade.MentorDisciplinaId);
            grade.Dia = _diaDAO.BuscarPorId(grade.DiaId);
            _gradeDAO.Cadastrar(grade);
            return RedirectToAction("Index", "Grade");
        }
        public IActionResult Remover(int id)
        {
            _gradeDAO.Remover(id);
            return RedirectToAction("Index", "Grade");
        }
        public IActionResult Alterar(int id)
        {
            return View(_gradeDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeDAO.Alterar(grade);
                return RedirectToAction("Index", "Grade");
            }
            return View(grade);
        }
    }
}
