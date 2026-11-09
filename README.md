# Catálogo Galactico API

## Contexto del Programa

Esta API REST hecha en .NET 10 con ASP.NET Core Web API usando controladores simula un juego de cartas. Los jugadores se registran y reciben 3 cartas aleatorias de un mazo general. Con esas cartas pueden ir a misiones, y si el poder total supera la dificultad de la misión, ganan puntos y una carta nueva. Todo se guarda en MySQL o MariaDB usando Entity Framework Core. Para la seguridad, las contraseñas se guardan hasheadas con BCrypt y el puntaje del jugador se guarda cifrado con AES para que no se pueda leer directo en la base de datos.

## Tecnologías Utilizadas

- .NET 10 y C#
- ASP.NET Core Web API con Controladores
- Entity Framework Core 9
- Pomelo para conectar con MySQL
- MySQL o MariaDB
- BCrypt para el hash de contraseñas
- Secret Manager para las claves

## Pasos para replicar el proyecto

### Requisitos previos

Tener el SDK de .NET 10 instalado.

Tener MySQL o MariaDB corriendo.

Instalar la herramienta global de EF Core en su versión 9 para que no choche con el conector de MySQL.

```bash
dotnet tool install --global dotnet-ef --version 9.0.0
```

### Clonar el repositorio e instalar dependencias

```bash
git clone https://github.com/Said-a-r/Proyecto-Creacion-API-MinimalAPIAHORASI.git
cd proyectoAPICatalogoW
dotnet restore
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add package BCrypt.Net-Next
```

### Configurar la Base de Datos

Entra a la consola de MySQL o MariaDB y ejecuta esto para crear la base y el usuario.

```sql
CREATE DATABASE proyectoAPICatalogoW CHARACTER SET utf8mb4;
CREATE USER 'catalogo_user'@'localhost' IDENTIFIED BY 'TuClaveSegura123';
GRANT ALL PRIVILEGES ON proyectoAPICatalogoW.* TO 'catalogo_user'@'localhost';
FLUSH PRIVILEGES;
```

### Configurar los secretos

Como no se debe subir contraseñas a GitHub se usa el Secret Manager de .NET.

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Port=3306;Database=proyectoAPICatalogoW;Uid=catalogo_user;Password=TuClaveSegura123;"
dotnet user-secrets set "Cifrado:Clave" "MDEyMzQ1Njc4OWFiY2RlZjAxMjM0NTY3ODlhYmNkZWY="
```

### Crear las tablas y ejecutar

Con las migraciones de Entity Framework se crean las tablas y se cargan los datos iniciales de personajes y cartas.

```bash
dotnet ef database update
```

Y por ultimo corres la API.

```bash
dotnet run
```

La API queda en http://localhost:5000 y la documentación en http://localhost:5000/swagger
