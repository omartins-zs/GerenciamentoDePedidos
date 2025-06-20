using GerenciamentoDePedidos.Domain.Models;
using System.Collections.Generic;

namespace GerenciamentoDePedidos.Domain.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll(string filtro);
        Produto GetById(int id);
        void Create(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
    }
}