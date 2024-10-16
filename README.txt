Proyecto que crea un crud para Usuarios y Vehiculos.
 Desarrollado en 
- Visual Studio FrameWork .net 7.0
- Microsoft SQL Server 2019

La Solución consta de 3 proyectos

    1. Proyecto Modelos Transversal
    2. Proyecto Servicios Web Api
    3. Proyecto Web MVC, que consume los servicios Api

Pasos Instalación:

1.   En el proyecto  Web Api configurar  cambiar la cadena de conexión en el archivo appsettings.json:
                                                                                                           
"ConnectionStrings": {
   "DefaultConnection": "Server=.\\SQLEXPRESS;Database=NectiaDB;Trusted_Connection=True;TrustServerCertificate=True;User id=sa;Password=123456789"
 }                                                                                                                                

2. Carpeta Data el archivo NectiaDbContext.cs Proyecto Web Api cambiar cadena de conexión: 

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=NectiaDB;TrustServerCertificate=True;User id=sa;Password=123456789");    
                                               
3.  Crear Base de datos  “NectiaDB” SQL Server, Carpeta ScripsDB Proyecto Web Api, ejecutar Scrips ScripsDB.sql.                                                                                           
                                                                                                                            
4. Proyecto Nectia.Web en el archivo appsettings.json configurar ruta donde se despliega proyecto Apis:

  "URLApi": { "URLApiKey": "https://localhost:7089/" }     