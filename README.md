## Gerenciamento de Pedidos

Este projeto é um sistema simplificado de **Gerenciamento de Pedidos** para uma pequena loja. Foi desenvolvido com **ASP.NET Core MVC**, **Dapper** e **SQL Server**, seguindo estrutura em camadas (Domain, Infra) e princípios básicos de separação de responsabilidades.

🧠 Este projeto teve ênfase especial na estrutura do backend, refletindo minha especialidade e experiência com arquitetura.
🎨 As views do frontend foram mantidas simples e funcionais, com foco na integração e teste dos fluxos.

### Funcionalidades
- **Autenticação**: Login, registro e logout de usuários, com sessões gerenciadas.
- **Clientes**: CRUD completo (listar, criar, editar, excluir) de clientes.
- **Produtos**: CRUD completo de produtos.
- **Pedidos**:
  - Listar pedidos com filtros por cliente e status.
  - Criar pedido: selecionar cliente, adicionar itens, calcular valor total.
  - Visualizar detalhes do pedido.
  - Atualizar status do pedido.

### Tecnologias
- **Backend**: C#, ASP.NET Core MVC (.NET 8)
- **ORM**: Dapper
- **Banco de Dados**: SQL Server (scripts de criação e inserção fornecidos)
- **Frontend**: Razor Views, Bootstrap 5, jQuery mínimo para itens dinâmicos
- **Sessão**: Implementação própria com `ISessao` e `System.Text.Json`

### Como executar
1. Crie o banco e execute `Scripts/Tables.sql` e `Scripts/Inserts.sql`.
2. Ajuste a string de conexão em `appsettings.json` (chave "Default").
3. No Visual Studio, restaure os pacotes NuGet (`Dapper`).
4. Execute o projeto (F5). Acesse `/Home/Index`.

### Estrutura de pastas
```
/Domain        Modelos e interfaces de repositório
/Infra         Implementações Dapper dos repositórios
/Controllers   Controllers MVC
/Views         Views Razor (Auth, Home, Cliente, Produto, Pedido)
/Helper        Sessão e criptografia de senha
/Scripts       SQL de criação e dados iniciais
Program.cs     Configuração minimal hosting
```

### 🚧 Melhorias e Escalabilidade Futuras
**Autenticação**
- Migrar para autenticação JWT (`Microsoft.AspNetCore.Authentication.JwtBearer`) para APIs RESTful, eliminando sessões de servidor.  

**Arquitetura**
- Migrar para microsserviços para permitir deploys independentes.  
- Utilizar RabbitMQ/Kafka para filas e processamento assíncrono de pedidos.  
- Adotar Clean Architecture com camada de Application separada.  

**Funcionalidades**
- Implementar inventário em tempo real e controle de lote.  
- Adicionar notificações via e-mail/SMS ao criar ou finalizar pedidos.  
- Permitir upload de catálogos de produtos em massa (CSV/Excel).  
- Documentar APIs REST usando Swagger (Swashbuckle) ou NSwag para facilitar testes e integração.  

**Observabilidade e Monitoramento**
- Integrar Application Insights ou ELK Stack para logging e métricas.  
- Monitorar performance de consultas Dapper e dimensionar índices no banco.  

**Referências**
- Sessão: `ISessao` + `System.Text.Json` para gerenciar usuário logado.  
- JWT: `Microsoft.AspNetCore.Authentication.JwtBearer` para autenticação sem estado.  
- Swagger: `Swashbuckle.AspNetCore` para documentação automática de endpoints.  
- Repositórios: uso de Dapper para mapeamento leve e performante.  
- Referencais e Auxiliares em: [https://github.com/seu-usuario/SistemaCadastroContatos](https://github.com/omartins-zs/SistemaCadastroContatos)
