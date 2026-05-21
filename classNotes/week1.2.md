# Software Design II
## Week 1.2
### Asynchronous programming
- Boils down to not blocking the main thread when performing long-running tasks  
- Especially important for maintaining responsive UIs and improving scalability  
  
```csharp
public static async Task PrepCleanAsync() {
        Console.WriteLine("Cleaning the house...");
        Task dishesTask = CleanDishesAsync();

        Vaccuum();
        Mop();

        await dishesTask;

        Console.WriteLine("House is clean.");
    }
```
- "asynch" keyword to designate method as asynchronous
- "await" means no further instructions in this method can be completed until task is completed
- "Task" is what is returned at some point in the future  
- used for file I/O, database access, anything that calls out to another service  

### Concurrency
- more than one thing happening at once
- asynch is just jumping between tasks, concurrency is true multitasking
- more than one thread doing things at the same time

### EF Core
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
dotnet add package Microsoft.EntityFrameworkCore.Sqlite;
```  
- database migrations:  
``` 
dotnet ef migrations add <MigrationName> 
```  
- execute unapplied migrations on the database (after the above command):  
``` 
dotnet ef database update 
```



#### EF Core Intro
#### Creation of Entity Models
##### Creation of Models
##### Data Annotations
#### Database Migration and Database Update
#### CRUD and Entity Tracking