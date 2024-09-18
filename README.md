# Padaria03
 Solução do desafio 2 do estudo de caso da padaria


tabelas

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