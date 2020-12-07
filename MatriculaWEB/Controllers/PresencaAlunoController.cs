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
    public class PresencaAlunoController : Controller
    {
        private readonly PresencaDAO _presencaDAO;
        private readonly ConjuntoAlunoDAO _conjuntoalunoDAO;
        private readonly GradeDAO _gradeDAO;
        private readonly UserManager<Usuario> _userManager;
        public PresencaAlunoController(PresencaDAO presencaDAO,
            ConjuntoAlunoDAO conjuntoalunoDAO,
            GradeDAO gradeDAO,
            UserManager<Usuario> userManager)
        {
            _presencaDAO = presencaDAO;
            _conjuntoalunoDAO = conjuntoalunoDAO;
            _gradeDAO = gradeDAO;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            string cpf = _userManager.GetUserName(User);
            return View(_presencaDAO.ListarPorAluno(cpf));
        }
    }
}
