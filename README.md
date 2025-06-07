# UserApi

API RESTful que permite la creación y autenticación de usuarios, generando un token con campos como `created`, `modified`, `last_login`, y `isActive`.

Se utilizaron tecnologías.NET 8.0, ASP.NET Core Web API, Entity Framework Core, SQL Server, etc.

## Cómo ejecutar:

1. Clonar el repositorio

git clone https://github.com/tuusuario/UserApi.git

2. En appsettings.json, configure su cadena de conexión:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=UserApiDb;Integrated Security=True;TrustServerCertificate=True"
}

3. Aplicar migraciones y crear base de datos

dotnet ef database update

4. Ejecutar la API

dotnet run

5. Probar en Postman

POST http://localhost:5000/api/usuarios

Ejemplo:
{
  "name": "Sara",
  "email": "sara@email.com",
  "password": "12345678",
  "phones": [
    {
      "number": "1234567",
      "citycode": "1",
      "countrycode": "57"
    }
  ]
}

--Script de creación de BD: el script SQL se generó desde las migraciones con:

dotnet ef migrations script -o Database/script.sql

Archivo contiene toda la estructura de la base de datos.
