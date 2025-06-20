using GerenciamentoDePedidos.Domain.Models;

namespace GerenciamentoDePedidos.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario GetByLogin(string login);
        void Add(Usuario usuario);
    }
}