using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Employee : HasId {
    [Required]
    public int Id { get; set; }
    public string FName { get; set;}
    public string LName { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; } //create actual email property here
    public int AdvanceId { get; set; }
    public Advance advance { get; set; }
    public static void createFullName(string FName, string LName){
        Func<string, string, string> FullName = (string fName, string lName) => fName +" "+lName;
    }
    public Employee(string FullName, string Department, string Email, string Phone){
        this.FullName = FullName;
        this.Department = Department;
        this.Email = Email;
        this.Phone = Phone;
    }
    //create function that allows admin user to add employee
}
public class Advent : HasId {
    [Required]
    public int Id { get; set; }
    public string name { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public Advance advance { get; set; }
    public int AdvanceId { get; set; }
    public Advent(string name, DateTime startDate, DateTime endDate, Advance advance)
    {
        this.name = name;
        this.startDate = startDate;
        this.endDate = endDate;
        this.advance = advance;
    } 
    // create function that allows admin user to create new event
}
public class Advance : HasId {
    [Required]
    public int Id { get; set; }
    public Advent advent { get; set; }
    public int AdventId { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public DateTime dueDate { get; set; }
    public Advance(DateTime dueDate, Advent advent, IEnumerable<Category> Categories){
        this.dueDate = dueDate;
        this.advent = advent;
        this.Categories = Categories;
    }
    // create function that allows admin user to create new advance
    // create function that allows admin user to issue new advance to employee (and therefore a specific department)
    // create function that allows admin user to approve/deny advance
    // create function that allows employee user to respond to an advance request

}
public class Category : HasId { 
    [Required]
    public int Id { get; set; }
    public int AdvanceId { get; set; }
    public Advance advance { get; set; }
    public string CategoryName { get; set; }
    public string Location { get; set; }
    public double Cost { get; set; }
    public IEnumerable<Option> Options { get; set; }
    public Category(string CategoryName, double Cost, IEnumerable<Option> Options){
        this.CategoryName = CategoryName;
        this.Cost = Cost;
        this.Options = Options;
    }
    // create function that allows admin user to create category and include in a particular advance
}
public class Option : HasId {
    [Required]
    public int Id { get; set; }
    public string OptionName { get; set; }
    public int CategoryId { get; set; }
    public Category category { get; set; }
    public Option(string OptionName){
        this.OptionName = OptionName;
    }
    //create function that allows admin user to set options in a category and assign it to a specific category
    // create function that allows employee user to choose from options and post that to advance
}

public partial class DB : IdentityDbContext<IdentityUser> {
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Advent> Advents { get; set; }
    public DbSet<Advance> Advances { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Option> Options { get; set; }
}

public partial class Handler {
    public void RegisterRepos(IServiceCollection services){
        Repo<Employee>.Register(services, "Employees");
        Repo<Advent>.Register(services, "Advents");
        Repo<Advance>.Register(services, "Advances");
        Repo<Category>.Register(services, "Categories");
        Repo<Option>.Register(services, "Options");
    }
}




    
