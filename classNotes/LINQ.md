# Software Design II
## LINQ
- querying syntax integrated into .NET allowing queries to be written directly into code
- "used to query in a stringly-typed, object-oriented manner"

### Benefits of LINQ
1. **Readability and Maintainability**: LINQ queries are more readable and maintainable compared to traditional SQL queries embedded as strings.
2. **Compile-time Checking**: LINQ provides compile-time checking of queries, which helps catch errors early.
3. **Integration with .NET**: LINQ integrates seamlessly with .NET languages, allowing for the use of language features like type inference and anonymous types.
4. **Consistency**: LINQ provides a consistent way to query different data sources.


- anything you can iterate over (innumerable): array of numbers, dictionary, etc.
```sql
SELECT Name, City
FROM Customers
WHERE City = 'London'
```
LINQ version:  
```csharp
/*
	The "_context" variable here would be the connection to the database, 
	and the "Customers" part right after would be the "Customers" table.
*/
let newList = numbers.ForEach(elem => elem > 2);

var customersList = await _context.Customers 
	.Where(c => c.City == "London") 
	.Select(c => new { Name = c.Name, City = c.City })
  // this select line is projection: for those people, create a new object
  // from here on, not customers anymore
	.ToListAsync();

/*
	Alternatively the below query accomplishes the same result as the
	above, you just do not need to use the Select() portion
	if you want the entire Customer object retrieved.
*/	
var altCustomersList = await _context.Customers 
	.Where(c => c.City == "London")
	.ToListAsync();
  ```
- notice that the 'where' comes **before** the select  
  - first filter, then manipulate the result  
- ``` .ToListAsynch() ``` location matters
- .FindAsynch does not work with joins  
- ...orDefault part means it returns default if not found (typically null)  
  - if not included, will throw exception if not found
- SingleDefaultAsynch() returns one; if multiple are found it throws an exception  
- FirstOrDefaultAsynch() returns the first one found, ignores subsequent instances  
  ```
  SingleDefaultAsynch() => 1
    Instructors [1, 1, 2, 3] // ERROR
  
  FirstOrDefaultAsynch()
    Instructors [1, 1, 2, 3] // OK
  ```

#### Immediate vs Deferred Execution
- things 'at the end' (```.ToListAsynch()```) causes the query to actually execute (deferred)  
-
### DTO
Data Transfer Object  






## Services and Dependency Injection
### Creating and Registering a Service
### Dependency Injection


