# UserApi

API RESTful que permite la creación y autenticación de usuarios, generando un token con campos como `created`, `modified`, `last_login`, y `isActive`.

Se utilizaron tecnologías.NET 8.0, ASP.NET Core Web API, Entity Framework Core, SQL Server, etc.

## Cómo ejecutar:

1. Clonar el repositorio

git clone https://github.com/sarahbbA3/UserApi.git

2. En appsettings.json, configure su cadena de conexión:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=UserApiDb;Integrated Security=True;TrustServerCertificate=True"
}

3. Aplicar migraciones y crear base de datos (en bash)

dotnet ef database update

4. Ejecutar la API (bash)

dotnet run

5. Probar en Postman

POST http://localhost:5085/api/usuarios

Ejemplo correcto:
{
  "name": "Sara",
  "email": "sara@gmail.com",
  "password": "Prueba33",
  "phones": [
    {
      "number": "1234567",
      "citycode": "1",
      "contrycode": "57"
    }
  ]
}

Ejemplo con error por formato de correo:
{
  "name": "Juan",
  "email": "juan@gmailcom",
  "password": "Prueba33",
  "phones": [
    {
      "number": "1234567",
      "citycode": "1",
      "contrycode": "57"
    }
  ]
}

Ejemplo con error por formato de contraseña:
{
  "name": "Pedro",
  "email": "pedro@gmail.com",
  "password": "prueba33",
  "phones": [
    {
      "number": "1234567",
      "citycode": "1",
      "contrycode": "57"
    }
  ]
}

--Script de creación de BD: el script SQL se generó desde las migraciones con:

dotnet ef migrations script -o Database/script.sql

Archivo contiene toda la estructura de la base de datos.

Script

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


