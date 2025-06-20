IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL DROP TABLE dbo.Usuarios;
IF OBJECT_ID('dbo.ItensPedido', 'U') IS NOT NULL DROP TABLE dbo.ItensPedido;
IF OBJECT_ID('dbo.Pedidos', 'U') IS NOT NULL DROP TABLE dbo.Pedidos;
IF OBJECT_ID('dbo.Produtos', 'U') IS NOT NULL DROP TABLE dbo.Produtos;
IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL DROP TABLE dbo.Clientes;

CREATE TABLE Usuarios (
    Id INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Login NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Perfil INT NOT NULL,
    Senha NVARCHAR(255) NOT NULL,
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
    DataAtualizacao DATETIME NULL
);

CREATE TABLE Clientes (
    Id INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Telefone NVARCHAR(20),
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Produtos (
    Id INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255),
    Preco DECIMAL(18,2) NOT NULL,
    Estoque INT NOT NULL
);

CREATE TABLE Pedidos (
    Id INT IDENTITY PRIMARY KEY,
    ClienteId INT NOT NULL,
    DataPedido DATETIME NOT NULL DEFAULT GETDATE(),
    ValorTotal DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY(ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE ItensPedido (
    Id INT IDENTITY PRIMARY KEY,
    PedidoId INT NOT NULL,
    ProdutoId INT NOT NULL,
    Quantidade INT NOT NULL,
    PrecoUnitario DECIMAL(18,2) NOT NULL,
    FOREIGN KEY(PedidoId) REFERENCES Pedidos(Id),
    FOREIGN KEY(ProdutoId) REFERENCES Produtos(Id)
);