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
    public class ConjuntoAlunoController : Controller
    {
        private readonly ConjuntoAlunoDAO _conjuntoalunoDAO;
        private readonly TurmaDAO _turmaDAO;
        private readonly AlunoDAO _alunoDAO;
        public ConjuntoAlunoController(ConjuntoAlunoDAO conjuntoalunoDAO,
            TurmaDAO turmaDAO,
            AlunoDAO alunoDAO)
        {
            _conjuntoalunoDAO = conjuntoalunoDAO;
            _turmaDAO = turmaDAO;
            _alunoDAO = alunoDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de relacionamento Mentores x Disciplinas";
            return View(_conjuntoalunoDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            ViewBag.Turmas = new SelectList(_turmaDAO.Listar(), "Id", "Nivel");
            ViewBag.Alunos = new SelectList(_alunoDAO.Listar(), "Id", "Nome");
            //ViewBag.ConjuntoAlunos = new SelectList(_conjuntoalunoDAO.Listar(), "Id", "Nome");
            //ViewData["Id"] = new SelectList(_alunoDAO.Listar(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Aluno alunos, ConjuntoAluno conjuntoaluno)
        {
            //mentordisciplina.Mentor = _mentorDAO.BuscarPorId(mentordisciplina.MentorId);
            //mentordisciplina.Disciplina = _disciplinaDAO.BuscarPorId(mentordisciplina.DisciplinaId);
            //var resultForm = Request?.Form.ToString();
            var resultForm2 = HttpContext.Request.Form["framework[]"];
            if (resultForm2.Count != 0)
            {
                foreach (var ca in resultForm2)
                {
                    ConjuntoAluno newconjuntoaluno = new ConjuntoAluno();
                    int id = int.Parse(ca);
                    Aluno aluno = _alunoDAO.BuscarPorId(id);
                    newconjuntoaluno.Aluno = aluno;

                    Turma turma = new Turma();
                    turma = _turmaDAO.BuscarPorId(conjuntoaluno.TurmaId);
                    newconjuntoaluno.Turma = turma;
                    _conjuntoalunoDAO.Cadastrar(newconjuntoaluno);
                }
                return RedirectToAction("Index", "ConjuntoAluno");
            }
            ViewBag.Turmas = new SelectList(_turmaDAO.Listar(), "Id", "Nivel");
            ViewBag.Alunos = new SelectList(_alunoDAO.Listar(), "Id", "Nome");
            ModelState.AddModelError("", "Selecionar pelo menos 1 aluno!");
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
