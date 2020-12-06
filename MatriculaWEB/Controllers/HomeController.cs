using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using MatriculaWEB.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AlunoDAO _alunoDAO;
        private readonly MentorDAO _mentorDAO;
        private readonly Sessao _sessao;
        private readonly ConjuntoAlunoDAO _conjuntoAlunoDAO;
        private readonly UsuarioViewDAO _usuarioViewDAO;
        public HomeController(Context context, UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager, RoleManager<IdentityRole> roleManager,
            AlunoDAO alunoDAO, MentorDAO mentorDAO, Sessao sessao, ConjuntoAlunoDAO conjuntoAlunoDAO,
            UsuarioViewDAO usuarioViewDAO)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _alunoDAO = alunoDAO;
            _mentorDAO = mentorDAO;
            _sessao = sessao;
            _conjuntoAlunoDAO = conjuntoAlunoDAO;
            _usuarioViewDAO = usuarioViewDAO;
        }
        public IActionResult Index()
        {
            //guardando tipo do usuário
            string cpf = _userManager.GetUserName(User);
            UsuarioView usuarioview = _usuarioViewDAO.BuscarPorCpf(cpf);
            string tipousuario = usuarioview.TipoUsuario;
            _sessao.BuscarTipoUsuario(tipousuario);
            //

            if (tipousuario == "Aluno")
            {
                //guardando a turma na sessão
                ConjuntoAluno conjuntoaluno = _conjuntoAlunoDAO.BuscarConjuntoAlunoPorCpf(cpf);
                int idturma = conjuntoaluno.Turma.Id;
                _sessao.BuscarTurmaId(idturma);
                //
            }
            return View();
        }
    }
}
