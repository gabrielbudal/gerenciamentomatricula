using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MatriculaWEB.DAL;
using MatriculaWEB.Utils;

namespace MatriculaWEB.Controllers
{
    public class UsuarioController : Controller
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

        public UsuarioController(Context context, UserManager<Usuario> userManager,
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

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioView = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioView == null)
            {
                return NotFound();
            }

            return View(usuarioView);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model, UsuarioView usuarioView)
        {
            if (ModelState.IsValid)
            {
                Aluno validaaluno = _alunoDAO.BuscarPorCpf(model.Cpf);
                if (validaaluno != null)
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
                        var applicationRole = await _roleManager.FindByNameAsync("Aluno");
                        if (applicationRole != null)
                        {
                            IdentityResult roleResult = await _userManager.AddToRoleAsync(usuario, applicationRole.Name);
                        }
                        //-------------------atribuir role ao user------------------------------

                        usuarioView.TipoUsuario = "Aluno";
                        _context.Add(usuarioView);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Login));
                    }
                    AdicionarErros(resultado);
                } else
                {
                    Mentor validamentor = _mentorDAO.BuscarPorCpf(model.Cpf);
                    if (validamentor != null)
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
                            var applicationRole = await _roleManager.FindByNameAsync("Mentor");
                            if (applicationRole != null)
                            {
                                IdentityResult roleResult = await _userManager.AddToRoleAsync(usuario, applicationRole.Name);
                            }
                            //-------------------atribuir role ao user------------------------------

                            usuarioView.TipoUsuario = "Mentor";
                            _context.Add(usuarioView);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Login));
                        }
                        AdicionarErros(resultado);
                    }
                }
                ModelState.AddModelError("", "Você não possui pré-cadastro realizado, por gentileza reveja seus dados ou entre em contato com a secretaria!");
            }
            return View(model);
        }

        public void AdicionarErros (IdentityResult resultado)
        {
            foreach (var erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioView usuarioView)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioView.Cpf, usuarioView.Senha, 
                false, false);
            string name = _signInManager.Context.User.Identity.Name;
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Login ou senha inválidos!");
            return View(usuarioView);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Usuario");
        }
    }
}
