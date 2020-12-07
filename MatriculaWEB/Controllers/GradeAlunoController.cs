using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class GradeAlunoController : Controller
    {
        private readonly GradeDAO _gradeDAO;
        private readonly TurmaDAO _turmaDAO;
        private readonly MentorDisciplinaDAO _mentordisciplinaDAO;
        private readonly DiaDAO _diaDAO;
        private readonly UserManager<Usuario> _userManager;
        private readonly ConjuntoAlunoDAO _conjuntoAlunoDAO;
        public GradeAlunoController(GradeDAO gradeDAO,
            TurmaDAO turmaDAO,
            MentorDisciplinaDAO mentordisciplinaDAO,
            DiaDAO diaDAO,
            UserManager<Usuario> userManager,
            ConjuntoAlunoDAO conjuntoAlunoDAO)
        {
            _gradeDAO = gradeDAO;
            _turmaDAO = turmaDAO;
            _mentordisciplinaDAO = mentordisciplinaDAO;
            _diaDAO = diaDAO;
            _userManager = userManager;
            _conjuntoAlunoDAO = conjuntoAlunoDAO;
        }
        public IActionResult Index()
        {
            string cpf = _userManager.GetUserName(User);
            ConjuntoAluno conjuntoaluno = _conjuntoAlunoDAO.BuscarConjuntoAlunoPorCpf(cpf);
            Turma turma = conjuntoaluno.Turma;

            return View(_gradeDAO.ListarPorTurma(turma));
        }
    }
}
