using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System;
    
[Route("/api/googleapi")]
public class GoogleAPIController<T> : Controller where T: class, HasId {
   
    public IRepository<T> r;
    public GoogleAPIController(IRepository<T> r) {
        this.r = r;
    }
    string key = "AIzaSyAtkcKhu5sly4w5dvFFFvvUzI7o15tea3c";
    public string urlFormat(string address, string key) =>
        $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={key}";
    // Task that receives JSON from a request to the Google GeoCoding API
    [HttpGet]
    public async Task<string> GetJSON([FromForm]string address){
        var http = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, urlFormat(address, key));
        var reply = await http.SendAsync(request);
        var result = await reply.Content.ReadAsStringAsync();
        return result;
    }
   
}

[Route("api/employee")]
public class EmployeeController : CRUDController<Employee> {
    public EmployeeController(IRepository<Employee> r) : base(r){}
}

[Route("api/advent")]
public class AdventController : CRUDController<Advent> {
    public AdventController(IRepository<Advent> r) : base(r){}
}

[Route("/api/advance")]
public class AdvanceController : CRUDController<Advance> {
    public AdvanceController(IRepository<Advance> r) : base(r){}
}

[Route("/api/section")]
public class SectionController : CRUDController<Section> {
    public SectionController(IRepository<Section> r) : base(r){}
}

[Route("/api/category")]
public class CategoryController : CRUDController<Category> {
    public CategoryController(IRepository<Category> r) : base(r){}
}

[Route("/api/option")]
public class OptionController : CRUDController<Option> {
    public OptionController(IRepository<Option> r) : base(r){}
}


