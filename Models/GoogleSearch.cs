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
using Newtonsoft.Json;
using System.Net.Http;

namespace GoogleSearch {
public class AddressComponent
{
    public string long_name { get; set; }
   
}

public class Location
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Geometry
{
    public Location location { get; set; }
   
}

public class Result
{
    public List<AddressComponent> address_components { get; set; }
    public string formatted_address { get; set; }
    public Geometry geometry { get; set; }
    public List<string> types { get; set; }
}

public class RootObject
{
    public List<Result> results { get; set; }
}
}