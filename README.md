#  TaskManager - Sistema de Gestión de Tareas
Sistema de registro y gestión para centralizar y administrar el ciclo de vida de todas las tareas dentro de la organización.

# Tecnologías utilizadas

## Backend
- .NET 8 
- Entity Framework Core (ORM)
- SQL Server 
- ASP.NET Core Web API
## Frontend
- React.js + Vite

# Requisitos previos
Antes de comenzar, asegúrate de tener instalado:

- .NET SDK (versión 6.0 o superior)
- Node.js 
- SQL Server 
- Git

# Configuración de la base de datos y migraciones

Instalar la herramienta dotnet-ef (si no tiene la herramienta CLI):
dotnet tool install --global dotnet-ef

para verificar:
dotnet ef --version

# Configurar la cadena de conexión

Edita el archivo appsettings.json (o appsettings.Development.json) dentro del proyecto backend:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

#  Crear la migración inicial

Desde la raíz del proyecto backend

    - dotnet ef migrations add InitialCreate 

Esto generará una carpeta Migrations con los archivos necesarios.


Aplicar la migración a la base de datos

dotnet ef database update

Este comando creará la base de datos y todas las tablas definidas en el modelo.