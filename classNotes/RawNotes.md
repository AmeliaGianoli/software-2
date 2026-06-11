- LINQ examples
  - ```.Include``` used to use the FK object  

- DTOs and Cycling

#### 6/11/26
What I should know:
  - classes
    - what they are/how to use
    - blueprint
    - inheritance
      - value of using this
      - single inheritance
      - polymorphism
    - public/private/protected
  - methods
    - reasons we write them
    - return types
    - parameters
      - overloading (same name, diff. parameters/data types)/overriding("replacing" inherited methods) [parent:  virtual method(){}; children: override method(){}]
  - interfaces
    - differneces beween these and classes
    - contract declaring abilities
    - use cases for interfaces
    - can implement multiple
    - can use as datatype but *cannot* instantiate
  - EF Core being an ORM System
    - that picture we have seen a billion times

things that are fuzzy:
  - packages needed for a project
  - database migrations
    - creating entities
    - ApplicationDbContext and registering entities here
    - migration command vs update command
  - registration & general setup of Program.cs
    - creating the ServiceCollection
    - building the ServiceProvider from the ServiceCollection
      - retrieving things from ServiceProvider
    when order matters in Program.cs
    - the lifetime scope of things added to ServiceCollection
  - LINQ

#### PROCESS
- class/models/entities => meat & potatoes
  - what do we need to work with?
  - relationship to one another
- creating the ApplicationDbContext
  - connection to DB
  - tell EF Core what models to make the tables from
- register ApplicationDbContext in the Program.cs
  - allows for dependency injection 
    - means that any other class (your services) that you create can interact with your database

/**************************************************/

- database migration and update => foundation is complete
  - only updated if schema changes

/**************************************************/

- Create whatever services needed
- register service(s) in the Program.cs
  - repeat pattern of:
    1. Define class
    2. Register in Program.cs
