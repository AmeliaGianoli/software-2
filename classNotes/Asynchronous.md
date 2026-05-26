# Software Design II
## Asynchronous programming
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

  - when performing certain actions, other actions can be done unrelated to the original action; standing waiting for something to finish before being able to do anything else
  - used primarily with FIle I/O

  ```csharp
  // code

  List<Movie> movies = await GetMovies();
  foreach(var movie in movies){
  }
// more code that can run while the previous lines are running
  ```  

## Concurrency
- more than one thing happening at once
- asynch is just jumping between tasks, concurrency is true multitasking
- more than one thread doing things at the same time

