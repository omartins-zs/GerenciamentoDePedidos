using System.Data;
using Dapper;
using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;

namespace GerenciamentoDePedidos.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _db;
        public UsuarioRepository(IDbConnection db) => _db = db;

        public Usuario GetByLogin(string login) =>
            _db.QuerySingleOrDefault<Usuario>(
                "SELECT * FROM Usuarios WHERE Login = @login", new { login });

        public void Add(Usuario usuario) =>
            _db.Execute(
                @"INSERT INTO Usuarios (Nome, Login, Email, Perfil, Senha, DataCadastro)
                  VALUES (@Nome, @Login, @Email, @Perfil, @Senha, GETDATE())", usuario);
    }
}