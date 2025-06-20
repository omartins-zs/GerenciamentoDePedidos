using Dapper;
using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GerenciamentoDePedidos.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _db;
        public ProdutoRepository(IDbConnection db) => _db = db;

        public IEnumerable<Produto> GetAll(string filtro) =>
            _db.Query<Produto>(
                "SELECT * FROM Produtos WHERE (@filtro IS NULL OR Nome LIKE '%' + @filtro + '%')",
                new { filtro });

        public Produto GetById(int id) =>
            _db.QueryFirstOrDefault<Produto>(
                "SELECT * FROM Produtos WHERE Id = @id", new { id });

        public void Create(Produto produto) =>
            _db.Execute(
                "INSERT INTO Produtos (Nome, Descricao, Preco, Estoque) VALUES (@Nome, @Descricao, @Preco, @Estoque)",
                produto);

        public void Update(Produto produto) =>
            _db.Execute(
                "UPDATE Produtos SET Nome=@Nome, Descricao=@Descricao, Preco=@Preco, Estoque=@Estoque WHERE Id=@Id",
                produto);

        public void Delete(int id) =>
            _db.Execute("DELETE FROM Produtos WHERE Id = @id", new { id });
    }
}