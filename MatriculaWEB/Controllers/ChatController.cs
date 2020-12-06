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
    public class ChatController : Controller
    {
        private readonly ChatDAO _chatDAO;
        private readonly TurmaDAO _turmaDAO;
        private readonly UserManager<Usuario> _userManager;
        private readonly ConjuntoAlunoDAO _conjuntoAlunoDAO;
        public ChatController(ChatDAO chatDAO, 
            TurmaDAO turmaDAO, 
            UserManager<Usuario> userManager,
            ConjuntoAlunoDAO conjuntoAlunoDAO)
        {
            _chatDAO = chatDAO;
            _turmaDAO = turmaDAO;
            _userManager = userManager;
            _conjuntoAlunoDAO = conjuntoAlunoDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Chat da turma";
            string cpf = _userManager.GetUserName(User);
            ConjuntoAluno conjuntoaluno = _conjuntoAlunoDAO.BuscarConjuntoAlunoPorCpf(cpf);
            int idturma = conjuntoaluno.Turma.Id;
            ViewBag.IdTurma = idturma;
            return View(_turmaDAO.BuscarTurmaPorIdLista(idturma));
        }
        public IActionResult BatePapo(int id)
        {
            Turma t = new Turma();
            t = _turmaDAO.BuscarTurmaPorId(id);

            ViewBag.IdTurma = t.Id;
            return View(_chatDAO.ListarPorTurma(id));
        }
        [HttpPost]
        public IActionResult Cadastrar(Chat chat)
        {
            var resultForm = HttpContext.Request.Form["msg"];
            var resultForm2 = int.Parse(HttpContext.Request.Form["idturma"]);
            Turma turma = _turmaDAO.BuscarTurmaPorId(resultForm2);

            chat.Mensagem = resultForm;
            chat.Cpf = _userManager.GetUserName(User);
            chat.Turma = turma;
            
            _chatDAO.Cadastrar(chat);
            return RedirectToAction("Index", "Chat");
        }
    }
}
