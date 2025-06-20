using GerenciamentoDePedidos.Domain.Models;
using System.Collections.Generic;

namespace GerenciamentoDePedidos.Domain.Repositories
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> GetAll(int? clienteId, string status);
        Pedido GetById(int id);
        int Create(Pedido pedido);
        void UpdateStatus(int id, string status);
    }
}
