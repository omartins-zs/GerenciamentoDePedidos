using Microsoft.AspNetCore.Mvc;
using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Helper;

namespace GerenciamentoDePedidos.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly ISessao _sessao;
        public MenuViewComponent(ISessao sessao) => _sessao = sessao;

        public IViewComponentResult Invoke()
        {
            var usuario = _sessao.BuscarSessaoDoUsuario();
            return View(usuario);
        }
    }
}