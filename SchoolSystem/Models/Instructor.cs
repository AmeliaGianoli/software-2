using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models;

public class Instructor
{

    [Key]
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    //    navigation property:
    public virtual Department? Department { get; set; }

    public DateTime JoiningDate { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}