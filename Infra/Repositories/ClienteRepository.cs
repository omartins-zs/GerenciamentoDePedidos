using Dapper;
using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GerenciamentoDePedidos.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _db;

        public ClienteRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Cliente> GetAll() =>
            _db.Query<Cliente>("SELECT * FROM Clientes");

        public Cliente GetById(int id) =>
            _db.QueryFirstOrDefault<Cliente>("SELECT * FROM Clientes WHERE Id = @id", new { id });

        public void Create(Cliente cliente) =>
            _db.Execute(
                "INSERT INTO Clientes (Nome, Email, Telefone, DataCadastro) VALUES (@Nome, @Email, @Telefone, GETDATE())",
                cliente);

        public void Update(Cliente cliente) =>
            _db.Execute(
                "UPDATE Clientes SET Nome=@Nome, Email=@Email, Telefone=@Telefone WHERE Id=@Id",
                cliente);

        public void Delete(int id) =>
            _db.Execute("DELETE FROM Clientes WHERE Id = @id", new { id });

        public IEnumerable<Cliente> Search(string termo) =>
            _db.Query<Cliente>(
                "SELECT * FROM Clientes WHERE Nome LIKE @termo OR Email LIKE @termo",
                new { termo = $"%{termo}%" });
    }
}
