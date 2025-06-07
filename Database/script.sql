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
CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    [LastLogin] datetime2 NOT NULL,
    [Token] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

CREATE TABLE [Phones] (
    [Id] int NOT NULL IDENTITY,
    [Number] nvarchar(max) NOT NULL,
    [CityCode] nvarchar(max) NOT NULL,
    [ContryCode] nvarchar(max) NOT NULL,
    [UserId] uniqueidentifier NULL,
    CONSTRAINT [PK_Phones] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Phones_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
);

CREATE INDEX [IX_Phones_UserId] ON [Phones] ([UserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250607144411_Init', N'9.0.5');

COMMIT;
GO

