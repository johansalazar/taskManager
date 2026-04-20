# taskManager
Descripción Funcional del Aplicativo de Gestión de tareas El aplicativo es un Sistema de Registro y Gestión para centralizar y administrar el ciclo de vida de todas las tareas dentro de la organización.

# CREAR MIGRACIÓN

SI no tienes instalado dotnet-ef (la herramienta CLI):
dotnet tool install --global dotnet-ef

para verificar:
dotnet ef --version

Desde la raíz del proyecto:
dotnet ef migrations add InitialCreate 
dotnet ef database update