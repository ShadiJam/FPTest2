using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("api/event")]
public class EventController : CRUDController<Event> {
    public EventController(IRepository<Event> r) : base(r){}
}

[Route("api/employee")]
public class EmployeeController : CRUDController<Employee> {
    public EmployeeController(IRepository<Employee> r) : base(r){}
}

[Route("api/location")]
public class LocationController : CRUDController<Location> {
    public LocationController(IRepository<Location> r) : base(r){}
}

[Route("/api/advance")]
public class AdvanceController : CRUDController<Advance> {
    public AdvanceController(IRepository<Advance> r) : base(r){}
}

[Route("/api/credential")]
public class CredentialController : CRUDController<Credential> {
    public CredentialController(IRepository<Credential> r) : base(r){}
}

[Route("/api/shirt")]
public class ShirtController : CRUDController<Shirt> {
    public ShirtController(IRepository<Shirt> r) : base(r){}
}

[Route("/api/parking")]
public class ParkingController : CRUDController<Parking> {
    public ParkingController(IRepository<Parking> r) : base(r){}
}

[Route("/api/hotel")]
public class HotelController : CRUDController<Hotel> {
    public HotelController(IRepository<Hotel> r) : base(r){}
}

[Route("/api/pettycash")]
public class PettyCashController : CRUDController<PettyCash> {
    public PettyCashController(IRepository<PettyCash> r) : base(r){}
}

[Route("/api/radio")]
public class RadioController : CRUDController<Radio> {
    public RadioController(IRepository<Radio> r) : base(r){}
}

[Route("/api/golfcart")]
public class GolfCartController : CRUDController<GolfCart> {
    public GolfCartController(IRepository<GolfCart> r) : base(r){}
}

[Route("/api/catering")]
public class CateringController : CRUDController<Catering> {
    public CateringController(IRepository<Catering> r) : base(r){}
    
}
