INSERT INTO Usuarios (Nome, Login, Email, Perfil, Senha, DataCadastro)
VALUES
  ('Admin Principal', 'admin', 'admin@loja.com', 1, 'admin123'.GerarHash(), GETDATE()),
  ('Carlos Pereira', 'carlosp', 'carlos@loja.com', 2, 'senha123'.GerarHash(), GETDATE()),
  ('Mariana Costa', 'marianac', 'mariana@loja.com', 2, 'senha123'.GerarHash(), GETDATE()),
  ('João Lima',     'joaol',    'joao@loja.com',     2, 'senha123'.GerarHash(), GETDATE()),
  ('Ana Souza',     'anas',     'ana@loja.com',      2, 'senha123'.GerarHash(), GETDATE());

INSERT INTO Clientes (Nome, Email, Telefone, DataCadastro)
VALUES
  ('Maria Silva',   'maria@cliente.com', '11999990000', GETDATE()),
  ('João Souza',    'joao@cliente.com',  '11988880000', GETDATE()),
  ('Pedro Alves',   'pedro@cliente.com','11977770000', GETDATE()),
  ('Luciana Rocha', 'luciana@cliente.com','11966660000', GETDATE()),
  ('Bruno Ferreira','bruno@cliente.com', '11955550000', GETDATE());

SET IDENTITY_INSERT Produtos ON;
INSERT INTO Produtos (Id, Nome, Descricao, Preco, Estoque)
VALUES
  (1, 'Notebook',    'Notebook i5 8GB RAM', 3500.00, 10),
  (2, 'Mouse',       'Mouse sem fio',        120.00, 50),
  (3, 'Teclado',     'Teclado mecânico',     250.00, 30),
  (4, 'Monitor',     'Monitor 24" IPS',     800.00, 20),
  (5, 'Headset',     'Headset com microfone',150.00, 25);
SET IDENTITY_INSERT Produtos OFF;

INSERT INTO Pedidos (ClienteId, DataPedido, ValorTotal, Status)
VALUES
  (1, GETDATE(), 3740.00, 'Novo'),
  (2, GETDATE(), 260.00, 'Processando');

INSERT INTO ItensPedido (PedidoId, ProdutoId, Quantidade, PrecoUnitario)
VALUES
  (1, 1, 1, 3500.00),
  (1, 2, 2, 120.00),
  (2, 3, 1, 250.00),
  (2, 4, 1, 10.00);