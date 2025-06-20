using GerenciamentoDePedidos.Domain.Models;

namespace GerenciamentoDePedidos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        Usuario BuscarSessaoDoUsuario();
        void RemoverSessaoDoUsuario();
    }
}