using Microsoft.AspNetCore.Mvc;
using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;
using GerenciamentoDePedidos.Helper;

namespace GerenciamentoDePedidos.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly ISessao _sessao;

        public AuthController(IUsuarioRepository usuarioRepo, ISessao sessao)
        {
            _usuarioRepo = usuarioRepo;
            _sessao = sessao;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            var usuario = _usuarioRepo.GetByLogin(login);
            if (usuario != null && usuario.Senha == senha.GerarHash())
            {
                _sessao.CriarSessaoDoUsuario(usuario);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Login ou senha inválidos.";
            return View();
        }

        public IActionResult Registro() => View();

        [HttpPost]
        public IActionResult Registro(Usuario model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_usuarioRepo.GetByLogin(model.Login) != null)
            {
                ViewBag.Error = "Login já cadastrado.";
                return View(model);
            }

            model.Senha = model.Senha.GerarHash();
            model.DataCadastro = DateTime.Now;
            _usuarioRepo.Add(model);

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Login");
        }
    }
}
