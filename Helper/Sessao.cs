using Microsoft.AspNetCore.Http;
using System.Text.Json;
using GerenciamentoDePedidos.Domain.Models;

namespace GerenciamentoDePedidos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext) => _httpContext = httpContext;

        public void CriarSessaoDoUsuario(Usuario usuario)
        {
            var valor = JsonSerializer.Serialize(usuario);
            _httpContext.HttpContext.Session.SetString("user", valor);
        }

        public Usuario BuscarSessaoDoUsuario()
        {
            var session = _httpContext.HttpContext.Session.GetString("user");
            return string.IsNullOrEmpty(session)
                ? null
                : JsonSerializer.Deserialize<Usuario>(session);
        }

        public void RemoverSessaoDoUsuario() => _httpContext.HttpContext.Session.Remove("user");
    }
}