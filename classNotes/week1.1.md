# Software Design II
## Week 1.1
### Versions
Version numbers 10.0.103

major.minor.minor (bugs)

### Class focus
- databases
- Using ORM system (Object Relational Mapping)

#### Use of ORM System => EF Core 
  - EF Core: layer of abstration between db and objects in memory
    - provides safety, scalability
    - standardized library for db interaction
    - eliminates need for custom syntax for each db system; transferrable to different DBMS


  - Application
    1. Be able to manipulate data
    2. be able to store (persist) data
  - In memory and out of memory copies
    - User model. changes need to be saved to database
    - Will have models that will have one-to-one mapping to db table
      - some models that are only in-memory copies; no db representation


#### Asyncronous 
  - when performing certain actions, other actions can be done unrelated to the original action; standing waiting for something to finish before being able to do anything else
  - used primarily with FIle I/O

  ```
  // code

  List<Movie> movies = await GetMovies();
  foreach(var movie in movies){
  }
// more code that can run while the previous lines are running
  ```

### Review
#### Datatypes
  - A collection of values and the calculations we can perform on those values.

  ```
  int x; 
  //contains integers

  bool y; 
  //contains true/false

  var x =8;
  x="Hello world" 
  // compilation error
  ```
  - more structure to datatypes allows for intellisense help, more safety/control

#### Errors
  - Compilation Error vs Runtime Error

    - Compilation Error happens at compilation: like a car that will not start; immediate knowledge of error

    - Runtime Error happens when running; like not connecting brake lines; unknown until it happens

#### OOP Paradigm
  - Allows us to write code that models the real world and how we think about it intuitively
  - Inheritance
    - Single inheritance => can only have 1 parent; cannot descend from 2 classes
    - As you move right in the line, need to get more specific; cannot become less specific
  - Scoping => public, private, protected

#### Lists
- Will use instead of array

```
int[] arr = {4, 5, 6}; 
// size = 3

// Later....

arr[3]=8;
// runtime error- outside bounds of arrray; need to create new array ove larger size, move originals over, then add 
```

  - List does not require resizing/management
  - List comes with a bunch of methods we can use for manipulation and save a ton of coding, protection from errors, etc. 

#### Generics
``` 
List<int> numbers = new List<int>();
// 'int' is the generic in this example
```
  - Generic is a variable for a datatype
  ```
  public class Box<T>{
    public T Item {get; set; }
  }
  //
  Box<bool> boxA = new Box<bool>();
  Box<decimal> boxB = new Box<decimal>();
  ```
  