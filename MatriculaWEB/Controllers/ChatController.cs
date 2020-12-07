using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using MatriculaWEB.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace MatriculaWEB.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatDAO _chatDAO;
        private readonly TurmaDAO _turmaDAO;
        private readonly UserManager<Usuario> _userManager;
        private readonly ConjuntoAlunoDAO _conjuntoAlunoDAO;
        private readonly Sessao _sessao;
        private readonly MentorDAO _mentorDAO;
        private readonly MentorDisciplinaDAO _mentorDisciplinaDAO;
        private readonly GradeDAO _gradeDAO;
        private readonly AlunoDAO _alunoDAO;
        public ChatController(ChatDAO chatDAO, 
            TurmaDAO turmaDAO, 
            UserManager<Usuario> userManager,
            ConjuntoAlunoDAO conjuntoAlunoDAO,
            Sessao sessao,
            MentorDAO mentorDAO,
            MentorDisciplinaDAO mentorDisciplinaDAO,
            GradeDAO gradeDAO,
            AlunoDAO alunoDAO)
        {
            _chatDAO = chatDAO;
            _turmaDAO = turmaDAO;
            _userManager = userManager;
            _conjuntoAlunoDAO = conjuntoAlunoDAO;
            _sessao = sessao;
            _mentorDAO = mentorDAO;
            _mentorDisciplinaDAO = mentorDisciplinaDAO;
            _gradeDAO = gradeDAO;
            _alunoDAO = alunoDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Chat da turma";
            string cpf = _userManager.GetUserName(User);
            string tipousuario = "";
            tipousuario = _sessao.BuscarTipoUsuario(tipousuario);

            if(tipousuario == "Aluno")
            { 
                int turma = 0;
                //ConjuntoAluno conjuntoaluno = _conjuntoAlunoDAO.BuscarConjuntoAlunoPorCpf(cpf);
                int idturma = _sessao.BuscarTurmaId(turma);
                ViewBag.IdTurma = idturma;
                return View(_turmaDAO.BuscarTurmaPorIdLista(idturma));
            } else
            {
                Mentor mentor = _mentorDAO.BuscarMentorPorCpf(cpf);
                List <MentorDisciplina> mentordisciplinas = _mentorDisciplinaDAO.ListarMentoresDisciplinasPorMentor(mentor);
                List<Grade> grades = _gradeDAO.ListarGradePorMentorDisciplina(mentordisciplinas);
                
                List<Turma> turmas = new List<Turma>();

                foreach (var ca in grades)
                {
                    turmas.Add(ca.Turma);
                }
                List<Turma> turmas2 = _turmaDAO.BuscarTurmaPorListaLista(turmas);
                return View(turmas2);
            }
        }
        public IActionResult BatePapo(int id)
        {
            string cpf = _userManager.GetUserName(User);
            string tipousuario = "";
            tipousuario = _sessao.BuscarTipoUsuario(tipousuario);

            if (tipousuario == "Aluno")
            {
                int turma = 0;
                turma = _sessao.BuscarTurmaId(turma);
                ViewBag.IdTurma = turma;
                return View(_chatDAO.ListarPorTurma(turma));
            } else
            {
                //var resultForm3 = int.Parse(HttpContext.Request.Form["idturma"]);
                ViewBag.IdTurma = id;
                return View(_chatDAO.ListarPorTurma(id));
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Chat chat)
        {
            string cpf = _userManager.GetUserName(User);
            string tipousuario = "";
            tipousuario = _sessao.BuscarTipoUsuario(tipousuario);

            if (tipousuario == "Aluno")
            {
                var resultForm = HttpContext.Request.Form["msg"];
                //var resultForm2 = int.Parse(HttpContext.Request.Form["idturma"]);
                int idturma = 0;
                idturma = _sessao.BuscarTurmaId(idturma);
                Turma turma = _turmaDAO.BuscarTurmaPorId(idturma);

                chat.Mensagem = resultForm;
                var cpf1 = _userManager.GetUserName(User);
                Aluno aluno1 = _alunoDAO.BuscarPorCpf(cpf1);
                chat.Cpf = aluno1.Nome;
                chat.Turma = turma;

                _chatDAO.Cadastrar(chat);
                return RedirectToAction("BatePapo", "Chat");
            } else
            {
                var resultForm = HttpContext.Request.Form["msg"];
                var resultForm2 = int.Parse(HttpContext.Request.Form["idturma"]);
                Turma turma = _turmaDAO.BuscarTurmaPorId(resultForm2);
                var cpf2 = _userManager.GetUserName(User);
                Mentor mentor1 = _mentorDAO.BuscarMentorPorCpf(cpf2);

                chat.Mensagem = resultForm;
                chat.Cpf = mentor1.Nome;
                chat.Turma = turma;

                _chatDAO.Cadastrar(chat);
                return RedirectToAction("Index", "Chat");
            }
        }
    }
}
