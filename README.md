# Padaria03
 Solução do desafio 2 do estudo de caso da padaria

*Algumas informações*

Desenvolvemos essa aplicação seguindo os padrões MVC e implementamos uma validação de entrada para todos os campos de cadastro.

Nossa aplicação possui certas limitações que não conseguimos solucionar.
Uma delas está na própria navegação entre páginas: Ao selecionar uma página de cadastro (Cliente, Produto ou venda) e tentar acessar uma outra página de cadastro, não é possível fazer de modo direto, é necessário ir a homepage primeiro para depois acessar outra página.

Atualmente, só é possível cadastrar uma venda a um cliente existente e os pontos não são computados.

Infelizmente não conseguimos desenvolver a API.
 


Tabelas para criação do banco

CREATE TABLE [dbo].[Clientes] (
    [IdCliente] INT            IDENTITY (1, 1) NOT NULL,
    [Nome]      NVARCHAR (60)  NOT NULL,
    [Cpf]       NVARCHAR (11)  NOT NULL,
    [Email]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);

CREATE TABLE [dbo].[Produto] (
    [IdProduto] INT             IDENTITY (1, 1) NOT NULL,
    [Nome]      NVARCHAR (100)  NOT NULL,
    [Preco]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([IdProduto] ASC)
);

CREATE TABLE [dbo].[Venda] (
    [IdVenda]    INT             IDENTITY (1, 1) NOT NULL,
    [IdCliente]  INT             NOT NULL,
    [IdProduto]  INT             NOT NULL,
    [ValorTotal] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED ([IdVenda] ASC),
    CONSTRAINT [FK_Venda_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_Venda_Produto] FOREIGN KEY ([IdProduto]) REFERENCES [dbo].[Produto] ([IdProduto])
);
