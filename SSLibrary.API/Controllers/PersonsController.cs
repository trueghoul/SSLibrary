using Microsoft.AspNetCore.Mvc;
using SSLibrary.API.Entities;

namespace SSLibrary.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    private ApplicationDbContext _context;
    // GET: api/Persons
    public PersonsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] {"value0", "value1", "value2"};
    }
}
