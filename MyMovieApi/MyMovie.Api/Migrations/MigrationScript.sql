IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Usuario] (
    [UsuarioId] int NOT NULL IDENTITY,
    [User] nvarchar(50) NOT NULL,
    [Senha] nvarchar(50) NOT NULL,
    [Email] nvarchar(50) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([UsuarioId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180704235144_Usuario', N'2.1.1-rtm-30846');

GO

CREATE TABLE [Categoria] (
    [CategoriaId] int NOT NULL IDENTITY,
    [Nome] nvarchar(30) NOT NULL,
    [CadastroUsuarioId] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [AlteracaoUsuarioId] int NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([CategoriaId]),
    CONSTRAINT [FK_Categoria_Usuario_AlteracaoUsuarioId] FOREIGN KEY ([AlteracaoUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Categoria_Usuario_CadastroUsuarioId] FOREIGN KEY ([CadastroUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Categoria_AlteracaoUsuarioId] ON [Categoria] ([AlteracaoUsuarioId]);

GO

CREATE INDEX [IX_Categoria_CadastroUsuarioId] ON [Categoria] ([CadastroUsuarioId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180708200154_Categoria', N'2.1.1-rtm-30846');

GO

CREATE TABLE [Filme] (
    [FilmeId] int NOT NULL IDENTITY,
    [Nome] nvarchar(30) NOT NULL,
    [Descricao] nvarchar(100) NOT NULL,
    [CategoriaId] int NOT NULL,
    [CadastroUsuarioId] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [AlteracaoUsuarioId] int NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Filme] PRIMARY KEY ([FilmeId]),
    CONSTRAINT [FK_Filme_Usuario_AlteracaoUsuarioId] FOREIGN KEY ([AlteracaoUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Filme_Usuario_CadastroUsuarioId] FOREIGN KEY ([CadastroUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Filme_Categoria_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([CategoriaId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Filme_AlteracaoUsuarioId] ON [Filme] ([AlteracaoUsuarioId]);

GO

CREATE INDEX [IX_Filme_CadastroUsuarioId] ON [Filme] ([CadastroUsuarioId]);

GO

CREATE INDEX [IX_Filme_CategoriaId] ON [Filme] ([CategoriaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180709150159_Filme', N'2.1.1-rtm-30846');

GO

