using GerenciamentoDePedidos.Domain.Models;
using System.Collections.Generic;

namespace GerenciamentoDePedidos.Domain.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
        IEnumerable<Cliente> Search(string termo);
    }
}
