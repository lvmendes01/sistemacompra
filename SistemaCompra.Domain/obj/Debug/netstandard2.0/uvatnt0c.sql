IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Produto] (
    [Id] uniqueidentifier NOT NULL,
    [Categoria] int NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SolicitacaoCompra] (
    [Id] uniqueidentifier NOT NULL,
    [Data] datetime2 NOT NULL,
    [Situacao] int NOT NULL,
    [CondicaoPagamento_Valor] int NULL,
    CONSTRAINT [PK_SolicitacaoCompra] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Item] (
    [Id] uniqueidentifier NOT NULL,
    [ProdutoId] uniqueidentifier NULL,
    [Qtde] int NOT NULL,
    [SolicitacaoCompraId] uniqueidentifier NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Item_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Item_SolicitacaoCompra_SolicitacaoCompraId] FOREIGN KEY ([SolicitacaoCompraId]) REFERENCES [SolicitacaoCompra] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Item_ProdutoId] ON [Item] ([ProdutoId]);

GO

CREATE INDEX [IX_Item_SolicitacaoCompraId] ON [Item] ([SolicitacaoCompraId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200211144713_Initial', N'3.1.1');

GO

ALTER TABLE [Produto] ADD [Preco] decimal(18,2) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200211150013_PrecoConfig', N'3.1.1');

GO

EXEC sp_rename N'[SolicitacaoCompra].[CondicaoPagamento_Valor]', N'CondicaoPagamento', N'COLUMN';

GO

ALTER TABLE [SolicitacaoCompra] ADD [NomeFornecedor] nvarchar(max) NULL;

GO

ALTER TABLE [SolicitacaoCompra] ADD [UsuarioSolicitante] nvarchar(max) NULL;

GO

ALTER TABLE [SolicitacaoCompra] ADD [TotalGeral] decimal(18,2) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200211170032_Add-SolicitacaoAndItem', N'3.1.1');

GO

ALTER TABLE [Produto] ADD [Situacao] int NOT NULL DEFAULT 1;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200212150007_AddSituacaoProduto', N'3.1.1');

GO

