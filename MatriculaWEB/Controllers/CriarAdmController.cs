using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using MatriculaWEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    public class CriarAdmController : Controller
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

        public CriarAdmController(Context context, UserManager<Usuario> userManager,
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
            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model, UsuarioView usuarioView)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    UserName = model.Cpf,
                    Email = model.Email
                };
                IdentityResult resultado = await _userManager.CreateAsync(usuario, model.Senha);
                if (resultado.Succeeded)
                {
                    //-------------------atribuir role ao user------------------------------
                    var applicationRole = await _roleManager.FindByNameAsync("Admin");
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(usuario, applicationRole.Name);
                    }
                    //-------------------atribuir role ao user------------------------------

                    usuarioView.TipoUsuario = "Admin";
                    _context.Add(usuarioView);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                AdicionarErros(resultado);
            }
            return View(model);
        }
        public void AdicionarErros(IdentityResult resultado)
        {
            foreach (var erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }
    }
}
