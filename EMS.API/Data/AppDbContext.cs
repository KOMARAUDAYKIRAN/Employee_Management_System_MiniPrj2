using EMS.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EMS.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<AppUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Unique constraints
    modelBuilder.Entity<Employee>()
        .HasIndex(e => e.Email)
        .IsUnique();

    // ✅ ADD THIS HERE
    modelBuilder.Entity<Employee>()
        .Property(e => e.Salary)
        .HasPrecision(18, 2);

    modelBuilder.Entity<AppUser>()
        .HasIndex(u => u.Username)
        .IsUnique();

        // ✅ Seed USERS (use STATIC HASH values ONLY)
        modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = 1,
                Username = "admin",
                PasswordHash = "$2a$11$f9JHDePctEWHjAMQz4oeZuypYZU/WAMMJxHc.SsNzaIlD4hoeWbKa",
                Role = "Admin",
                CreatedAt = DateTime.UtcNow
            },
            new AppUser
            {
                Id = 2,
                Username = "viewer",
                PasswordHash = "$2a$11$C.tlma4g6Ay.bUmEo8f3ueFJfNv7wtSFSV3D/jPBrYE7H/8buEG6G",
                Role = "Viewer",
                CreatedAt = DateTime.UtcNow
            }
        );

        // Seed EMPLOYEES
        modelBuilder.Entity<Employee>().HasData(
     new Employee { Id = 1, FirstName = "Uday", LastName = "Kiran", Email = "uday@gmail.com", Department = "IT", Designation = "Developer", Salary = 50000, Status = "Active" },

     new Employee { Id = 2, FirstName = "Kalyani", LastName = "Rao", Email = "kalyani@gmail.com", Department = "HR", Designation = "Manager", Salary = 45000, Status = "Inactive" },

     new Employee { Id = 3, FirstName = "Ravi", LastName = "Kumar", Email = "ravi@gmail.com", Department = "IT", Designation = "Tester", Salary = 55000, Status = "Active" },

     new Employee { Id = 4, FirstName = "Sita", LastName = "Devi", Email = "sita@gmail.com", Department = "Finance", Designation = "Accountant", Salary = 60000, Status = "Inactive" },

     new Employee { Id = 5, FirstName = "Arjun", LastName = "Reddy", Email = "arjun@gmail.com", Department = "MARKETING", Designation = "Executive", Salary = 52000, Status = "Active" },

     new Employee { Id = 6, FirstName = "Priya", LastName = "Sharma", Email = "priya@gmail.com", Department = "HR", Designation = "HR Executive", Salary = 48000, Status = "Inactive" },

     new Employee { Id = 7, FirstName = "Kiran", LastName = "Varma", Email = "kiran@gmail.com", Department = "Finance", Designation = "Consultant", Salary = 62000, Status = "Active" },

     new Employee { Id = 8, FirstName = "Meena", LastName = "Iyer", Email = "meena@gmail.com", Department = "SALES", Designation = "Sales Executive", Salary = 53000, Status = "Active" },

     new Employee { Id = 9, FirstName = "Rahul", LastName = "Das", Email = "rahul@gmail.com", Department = "SALES", Designation = "Sales Associate", Salary = 47000, Status = "Inactive" },

     new Employee { Id = 10, FirstName = "Anjali", LastName = "Mehta", Email = "anjali@gmail.com", Department = "Finance", Designation = "Analyst", Salary = 61000, Status = "Active" },

     new Employee { Id = 11, FirstName = "Vikram", LastName = "Singh", Email = "vikram@gmail.com", Department = "IT", Designation = "Team Lead", Salary = 58000, Status = "Active" },

     new Employee { Id = 12, FirstName = "Pooja", LastName = "Nair", Email = "pooja@gmail.com", Department = "MARKETING", Designation = "Coordinator", Salary = 46000, Status = "Inactive" },

     new Employee { Id = 13, FirstName = "Deepak", LastName = "Yadav", Email = "deepak@gmail.com", Department = "Finance", Designation = "Manager", Salary = 64000, Status = "Active" },

     new Employee { Id = 14, FirstName = "Sneha", LastName = "Patel", Email = "sneha@gmail.com", Department = "IT", Designation = "Developer", Salary = 51000, Status = "Active" },

     new Employee { Id = 15, FirstName = "Ajay", LastName = "Gupta", Email = "ajay@gmail.com", Department = "HR", Designation = "Executive", Salary = 49000, Status = "Inactive" }
 );
    }
}