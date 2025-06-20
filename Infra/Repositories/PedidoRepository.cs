using Dapper;
using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GerenciamentoDePedidos.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnection _db;
        public PedidoRepository(IDbConnection db) => _db = db;

        public IEnumerable<Pedido> GetAll(int? clienteId, string status)
        {
            var sql = @"
SELECT p.*, c.Id, c.Nome
FROM Pedidos p
JOIN Clientes c ON p.ClienteId = c.Id
WHERE (@clienteId IS NULL OR p.ClienteId = @clienteId)
  AND (@status IS NULL OR p.Status = @status)";
            return _db.Query<Pedido, Cliente, Pedido>(
                sql,
                (pedido, cliente) => { pedido.Cliente = cliente; return pedido; },
                new { clienteId, status },
                splitOn: "Id");
        }

        public Pedido GetById(int id)
        {
            var pedido = _db.QuerySingle<Pedido>(
                "SELECT * FROM Pedidos WHERE Id = @id",
                new { id });
            pedido.Itens = _db.Query<ItemPedido, Produto, ItemPedido>(
                @"
SELECT i.*, pr.Id, pr.Nome, pr.Descricao, pr.Preco, pr.QuantidadeEstoque
FROM ItensPedido i
JOIN Produtos pr ON i.ProdutoId = pr.Id
WHERE i.PedidoId = @id",
                (item, produto) => { item.Produto = produto; return item; },
                new { id },
                splitOn: "Id").ToList();
            return pedido;
        }

        public int Create(Pedido pedido)
        {
            using var tx = _db.BeginTransaction();
            var id = _db.ExecuteScalar<int>(
                @"INSERT INTO Pedidos (ClienteId, DataPedido, ValorTotal, Status)
                  VALUES (@ClienteId, @DataPedido, @ValorTotal, @Status);
                  SELECT CAST(SCOPE_IDENTITY() AS INT)",
                pedido, tx);
            foreach (var item in pedido.Itens)
            {
                item.PedidoId = id;
                _db.Execute(
                    @"INSERT INTO ItensPedido (PedidoId, ProdutoId, Quantidade, PrecoUnitario)
                      VALUES (@PedidoId, @ProdutoId, @Quantidade, @PrecoUnitario)",
                    item, tx);
            }
            tx.Commit();
            return id;
        }

        public void UpdateStatus(int id, string status) =>
            _db.Execute(
                "UPDATE Pedidos SET Status = @status WHERE Id = @id",
                new { id, status });
    }
}
