using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gianoli_ChinookCrudApp.Models.Entities;

public class Employee
{
  [Key]
  public int EmployeeId { get; set; }
  public required string LastName { get; set; }
  public required string FirstName { get; set; }
  public string? Title { get; set; }
  [ForeignKey("ReportsToManager")]
  public int? ReportsTo { get; set; }
  public virtual Employee? ReportsToManager { get; set; }
  public DateTime BirthDate { get; set; }
  public DateTime HireDate { get; set; }
  public string? Address { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? Country { get; set; }
  public string? PostalCode { get; set; }
  public string? Phone { get; set; }
  public string? Fax { get; set; }
  public string? Email { get; set; }
  public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
  public virtual ICollection<Employee> DirectReports { get; set; } = new List<Employee>();
}