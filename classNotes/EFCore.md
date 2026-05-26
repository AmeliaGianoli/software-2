# Software Design II
## EF Core
### EF Core Intro

- we do not want to be writing raw SQL queries (too much room for error, security, efficiency)
- Object-Relational Mapping (O/R Mapping)
- DbContext from EntityFrameworkCore
- installation:
    - globally:  
```
 dotnet tool install --global dotnet-ef 
 ```  
- within the project:  
```
dotnet add package Microsoft.EntityFrameworkCore.Design;
dotnet add package Microsoft.EntityFrameworkCore.Tools;
// for SQLite database:
dotnet add package Microsoft.EntityFrameworkCore.Sqlite;
```  

- maps the in-memory model (classes) to the database model (tables)  
- EF Core provides an interface across different database providers (SQL Server, SQLite, etc.)

### Creation of Entity Models
#### Creation of Models
- define models to represent the tables in the database
- we use the ```[key]``` keyword to designate PK
- use ```Collection``` to designate relationships
steps:  
1. create models
2. create dbcontext file
    - this is where we tell EF Core how to construct the DB and what models are a part of it
    - extends the dbContext model  
    - way we connect to the DB is DBM-specific  
        ```protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=school.db");```  
    - to create the tables:
     ```public DbSet<modelName> tblName {get; set; }```
3. register the applicationDbContext in Program.cs
```csharp
ServiceProvider _serviceProvider;
// Create container to hold services for dependency injection
var services = new ServiceCollection();
// Add services to service container
services.AddDbContext<ApplicationDbContext>();
/*
    Get the service provider - this is our way to take something
    out of the container.
*/
_serviceProvider = services.BuildServiceProvider();
```

#### Data Annotations
- ```[Key]```, ```[ForeignKey ("variableName")]``` (before the foreign key field), ```public virtual ModelName? variableName { get; set; }``` (follows the foreign key field; uses same varName as ForeignKey declaration)
### Database Migration and Database Update
- database migrations:  
``` 
dotnet ef migrations add <MigrationName> 
```  
- this command creates the Migrations directory
- to do this, code MUST be able to be compiled; no compilation errors
- creates 2 methods; up is what it does to the DB, down undos the changes
- migration command **DOES NOT** touch the database; it opnly creates the migration file

- execute unapplied migrations on the database (after the above command):  
```
dotnet ef database update 
```
- this command is what actually creates/updates the DB, tables, etc.
- also tracks changes to the schema of the DB
- need to re-run migrate command when changing schema


### CRUD and Entity Tracking