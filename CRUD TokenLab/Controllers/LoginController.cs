using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_TokenLab.Models;

namespace CRUD_TokenLab.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginContext _context;

        public LoginController(LoginContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View();
        }



        // GET: Employees/Create
        public IActionResult Registro()
        {
            return View(new Usuario());
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("Nome, Login, Senha, Email")] Usuario usuario)
        {
            var repetido = _context.usuarios.FirstOrDefault(item => item.Login == usuario.Login);

            if (repetido != null)
            {
                ModelState.AddModelError("Erro", "Já existe um funcionário com esta matrícula");
            }

            if (ModelState.IsValid)
            {

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Login, Senha")] Usuario usuario)
        {
            var UsuarioCadastrado = _context.usuarios.FirstOrDefault(item => item.Login == usuario.Login);

            if (UsuarioCadastrado == null)
            {
                ModelState.AddModelError("Erro", "Usuário não encontrado, senha ou login inconrretos");
            }

            if (ModelState.IsValid && UsuarioCadastrado.Senha == usuario.Senha)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ModelState.AddModelError("Erro", "Usuário não encontrado, senha ou login inconrretos");
            }
            return View("Index");
        }
    }
}
