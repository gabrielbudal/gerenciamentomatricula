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
    public class PresencaController : Controller
    {
        private readonly PresencaDAO _presencaDAO;
        private readonly ConjuntoAlunoDAO _conjuntoalunoDAO;
        private readonly GradeDAO _gradeDAO;
        public PresencaController(PresencaDAO presencaDAO, 
            ConjuntoAlunoDAO conjuntoalunoDAO,
            GradeDAO gradeDAO)
        {
            _presencaDAO = presencaDAO;
            _conjuntoalunoDAO = conjuntoalunoDAO;
            _gradeDAO = gradeDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Presenças";
            return View(_presencaDAO.Listar());
        }
        public IActionResult Cadastrar(int id)
        {
            Grade g = new Grade();
            g = _gradeDAO.BuscarGradePorId(id);

            //A partir da grade obteve a turma
            int idturma = g.Turma.Id;

            //A partir da turma obteve conjunto aluno que preencherá a grid
            ViewBag.ConjuntoAlunos = new SelectList(_conjuntoalunoDAO.BuscarConjuntoAlunoPorIdTurma(idturma), "Id", "Aluno");

            //ViewBag.ConjuntoAlunos = new SelectList(_conjuntoalunoDAO.Listar(), "Id", "Aluno");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(ConjuntoAluno conjuntoalunos, Presenca presenca)
        {
            var resultForm2 = HttpContext.Request.Form["framework[]"];
            if (resultForm2.Count != 0)
            {
                foreach (var ca in resultForm2)
                {
                    Presenca newpresenca = new Presenca();
                    int id = int.Parse(ca);
                    ConjuntoAluno conjuntoaluno = _conjuntoalunoDAO.BuscarPorId(id);
                    newpresenca.ConjuntoAluno = conjuntoaluno;

                    newpresenca.Grade = _gradeDAO.BuscarPorId(presenca.GradeId);
                    newpresenca.Presente = false;
                    _presencaDAO.Cadastrar(newpresenca);
                }
                return RedirectToAction("Index", "ConjuntoAluno");
            }
            ViewBag.ConjuntoAlunos = new SelectList(_conjuntoalunoDAO.Listar(), "Id", "Aluno");
            ViewBag.Grades = new SelectList(_gradeDAO.Listar(), "Id", "Turma");
            ModelState.AddModelError("", "Selecionar pelo menos 1 aluno!");
            return View(presenca);
        }
        public IActionResult ListaRealizar()
        {
            DateTime dataatual = DateTime.Now;
            string datavalidador = dataatual.ToString("dddd");
            return View(_gradeDAO.ListarGradeHoje(datavalidador));
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
