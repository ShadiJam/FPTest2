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

public class Event : HasId {
    [Required]
    public int Id { get; set; }
    public string name { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public string Location { get; set; }
    public IEnumerable<Advance> Advances { get; set; }
}
public class Employee : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public string firstName { get; set; }
    [Required]
    public string lastName { get; set; }
    [Required]
    public string department { get; set; }
    [Required]
    public string phone { get; set; }
    [Required]
    public string email { get; set; }
} // consider adding eventName to employee properties

public class Location : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public string name { get; set; }
    public double lattitude { get; set; }
    public double longitude { get; set; }

}
public class Advance : HasId {
    [Required]
    public int Id { get; set; }
    public Event Event { get; set; }
    public int EventId { get; set; }
    public string department { get; set; }
    public Employee employee { get; set; }
    public int EmployeeId { get; set; }
    public DateTime dueDate { get; set; }
    public bool wasSent { get; set; }
    public bool wasSubmitted { get; set; }
    public bool wasApproved { get; set; }
    public IEnumerable<Location> Locations { get; set; }
    public IEnumerable<Credential> Credentials { get; set; } 
    public IEnumerable<Shirt> Shirts { get; set; } 
    public IEnumerable<Parking> Passes { get; set; } 
    public IEnumerable<PettyCash> Amounts { get; set; } 
    public IEnumerable<Hotel> Rooms { get; set; } 
    public IEnumerable<Radio> Radios { get; set; } 
    public IEnumerable<GolfCart> Carts { get; set; } 
    public IEnumerable<Catering> Meals { get; set; } 
}
public class Credential : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    [Required]
    public int AdvanceId { get; set; }
    public string credType { get; set; }
    public string accessLevel { get; set; }
    public string color { get; set; }
    public double cost { get; set; }
}

public enum ShirtSize { XS, S, M, L, XL, XXL }
public class Shirt : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    [Required]
    public int AdvanceId { get; set; }
    public ShirtSize size { get; set; }
    public double cost { get; set; }
}

public class Parking : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    [Required]
    public int AdvanceId { get; set; }
    public string passType { get; set; }
    public DateTime weekDay { get; set; }
    public IEnumerable<Location> Locations { get; set; }
    public double cost { get; set; }
}

public class PettyCash : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    [Required]
    public int AdvanceId { get; set; }
    public double amountRequested { get; set; }
    public double amountApproved { get; set; }
    public DateTime pcNeededBy { get; set; }
    public Employee employee { get; set; }
    public int EmployeeId { get; set; }   
}
public enum RoomType { doubleRoom, kingRoom, suite}
public class Hotel : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    [Required]
    public int AdvanceId { get; set; }
    public Employee employee { get; set; }
    public int EmployeeId { get; set; }
    public RoomType type { get; set; }
    public DateTime checkIn { get; set; }
    public DateTime checkOut { get; set; }
    public bool eventPaysExpense { get; set; } 
    public string billTo { get; set; }
    public double cost { get; set; }
    public IEnumerable<Location> Locations { get; set; }
}

public class Radio : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    [Required]
    public int AdvanceId { get; set; }
    public string radioType { get; set; }
    public bool hasExtraBattery { get; set; }
    public bool hasExtraHeadSet { get; set; }
    public double cost { get; set; }
}

public class GolfCart : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    [Required]
    public int AdvanceId { get; set; }
    public string cartType { get; set; }
    public double cost { get; set; }
}

public class Catering : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public Advance advance { get; set; }
    public int AdvanceId { get; set; }
    public IEnumerable<Location> Locations { get; set; } // Hotel, CateringTent, Stage
    public string mealType { get; set; } // Breakfast, Lunch, Dinner, BoxBrek, BoxLunch, BoxDin
    public bool duringEventDays { get; set; } = false;
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public double cost { get; set; }
}

public partial class DB : IdentityDbContext<IdentityUser> {
    public DbSet<Event> Events { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Advance> Advances { get; set; }
    public DbSet<Credential> Credentials { get; set; }
    public DbSet<Shirt> Shirts { get; set; }
    public DbSet<Parking> Passes { get; set; }
    public DbSet<PettyCash> Amounts { get; set; }
    public DbSet<Hotel> Rooms { get; set; }
    public DbSet<Radio> Radios { get; set; }
    public DbSet<GolfCart> Carts { get; set; }
    public DbSet<Catering> Meals { get; set; }
}

public partial class Handler {
     public void RegisterRepos(IServiceCollection services){
        Repo<Event>.Register(services, "Events");
        Repo<Advance>.Register(services, "Advances");
        Repo<Employee>.Register(services, "Employees");
        Repo<Location>.Register(services, "Locations");
        Repo<Credential>.Register(services, "Credentials");
        Repo<Shirt>.Register(services, "Shirts");
        Repo<Parking>.Register(services, "Passes");
        Repo<PettyCash>.Register(services, "Amounts");
        Repo<Hotel>.Register(services, "Rooms");
        Repo<Radio>.Register(services, "Radios");
        Repo<GolfCart>.Register(services, "Carts");
        Repo<Catering>.Register(services, "Meals");
     }
}