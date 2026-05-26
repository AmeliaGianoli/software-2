
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Models.Dtos;


namespace SchoolSystem.Services;

public class BasicQueryService
{
    // An attribute for the ApplicationDbContext
    private readonly ApplicationDbContext _context;

    public BasicQueryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetAllInstructorNamesAsync()
    {
        return await _context.Instructors
            .Select(instructor => instructor.LastName)
            .ToListAsync();
    }

    public async Task<Instructor?> GetInstructorByIdAsync(int instructorId)
    {
        // return await _context.Instructors.FindAsync(instructorId);
        return await _context.Instructors
            .Include(instr => instr.Department)
            .SingleOrDefaultAsync(instr => instr.Id == instructorId);
    }

    public async Task<List<Department>> GetDepartmentsWithMoreThanOneCourseAsync()
    {
        return await _context.Departments
            .Where(dept => dept.Courses.Count > 0)
            .ToListAsync();
    }

    public async Task<string?> GetDepartmentWithMostCoursesAsync()
    {
        return await _context.Departments
            .OrderByDescending(dept => dept.Courses.Count)
            .Select(dept => dept.Name)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Student>> GetStudentsEnrolledInMoreThanFiveCoursesAsync()
    {
        return await _context.Students
            .Where(student => student.Courses.Count > 5)
            .ToListAsync();
    }

    public async Task<List<Student>> GetStudentsWithNoCoursesAsync()
    {
        return await _context.Students
            // .Where(student => student.Courses.Count ==0)
            .Where(s => !s.Courses.Any())
            .ToListAsync();
    }

    public async Task<Instructor?> GetInstructorWithMostCoursesAsync()
    {
        return await _context.Instructors
            .OrderByDescending(instr => instr.Courses.Count)
            .FirstOrDefaultAsync();
    }


    public async Task<List<List<Course>>> GetAllStudentCoursesAsync()
    {
        return await _context.Students
            .Include(students => students.Courses)
            .Select(s => s.Courses.ToList())
            .ToListAsync();
    }

    public async Task<List<Course>> GetAllStudentCoursesFlattenedAsync()
    {
        return await _context.Students
            .Include(students => students.Courses)
            .SelectMany(s => s.Courses)
            .ToListAsync();
    }

    // public async Task<List<Student>> GetStudentsInCourseAsync(string courseName)
    // {

    // }
    // public async Task<List<Course>> GetCoursesByInstructorAsync(string instructorName)
    // {

    // }
    // public async Task<List<Instructor?>> GetInstructorsInDepartmentAsync(string departmentName)
    // {

    // }

    public async Task<InstructorDto?> GetInstructorDtoByIdAsync(int instructorId)
    {
        // return await _context.Instructors.FindAsync(instructorId);
        return await _context.Instructors
        .Where(i => i.Id == instructorId)
            .Include(instr => instr.Department)
            .Include(instr => instr.Courses)
            .Select(instructor => new InstructorDto
            {
                LastName = instructor.LastName,
                DepartmentName = instructor.Department.Name
            })
            .SingleOrDefaultAsync();
    }
}