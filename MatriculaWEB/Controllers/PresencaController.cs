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
            int idgrade = g.Id;
            //A partir da turma obteve conjunto aluno que preencherá a grid
            ViewBag.IdGrade = idgrade;
            ViewBag.IdTurma = idturma;
            ViewBag.ConjuntoAlunos = new SelectList(_conjuntoalunoDAO.BuscarConjuntoAlunoPorIdTurma(idturma), "Id", "Aluno");

            //ViewBag.ConjuntoAlunos = new SelectList(_conjuntoalunoDAO.Listar(), "Id", "Aluno");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(ConjuntoAluno conjuntoalunos, Presenca presenca)
        {
            var resultForm2 = HttpContext.Request.Form["framework[]"];
            var resultForm3 = int.Parse(HttpContext.Request.Form["idturma"]);
            var resultForm4 = int.Parse(HttpContext.Request.Form["idgrade"]);

            //List<ConjuntoAluno> result = _conjuntoalunoDAO.BuscarConjuntoAlunoPorIdTurma(resultForm3);
            //var resultForm = Request?.Form;

            Grade g = new Grade();
            g = _gradeDAO.BuscarGradePorId(resultForm4);

            //alunos com falta
            if (resultForm2.Count != 0)
            {
                //primeiro marcar os com falta
                foreach (var ca in resultForm2)
                {
                    Presenca newpresenca = new Presenca();
                    ConjuntoAluno conjuntoaluno = new ConjuntoAluno();

                    int id = int.Parse(ca);
                    conjuntoaluno = _conjuntoalunoDAO.BuscarPorId(id);
                    newpresenca.ConjuntoAluno = conjuntoaluno;

                    newpresenca.Grade = g;
                    newpresenca.Presente = false;
                    _presencaDAO.Cadastrar(newpresenca);
                }

                //depois os sem falta
                List<int> alunosfaltasint = resultForm2.Select(int.Parse).ToList();
                List<ConjuntoAluno> alunopresentes = _conjuntoalunoDAO.BuscarConjuntoAlunoPorListaIds(alunosfaltasint, resultForm3);
                foreach (var ca in alunopresentes)
                {
                    Presenca newpresenca = new Presenca();
                    newpresenca.ConjuntoAluno = ca;
                    newpresenca.Grade = g;
                    newpresenca.Presente = true;
                    _presencaDAO.Cadastrar(newpresenca);
                }

            }
            //se não existiram faltas, presença para todos
            else
            {
                List<ConjuntoAluno> result = _conjuntoalunoDAO.BuscarConjuntoAlunoPorIdTurma(resultForm3);

                foreach (var ca in result)
                {
                    Presenca newpresenca = new Presenca();
                    newpresenca.ConjuntoAluno = ca;
                    newpresenca.Grade = g;
                    newpresenca.Presente = true;
                    _presencaDAO.Cadastrar(newpresenca);
                }
            }

            return RedirectToAction("Index", "Presenca");
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
