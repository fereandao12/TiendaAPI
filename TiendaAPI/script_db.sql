IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Productos] (
    [idProducto] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [EsAlimento] bit NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([idProducto])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251226193218_Inicial', N'9.0.0');

CREATE TABLE [Usuarios] (
    [idUsuario] int NOT NULL IDENTITY,
    [NombreUsuario] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Rol] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([idUsuario])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251228001821_Nueva tabla', N'9.0.0');

COMMIT;
GO

