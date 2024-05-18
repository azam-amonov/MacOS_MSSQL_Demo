using Demo_MSSQL_MacOS.Models;
using Demo_MSSQL_MacOS.Service;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MSSQL_MacOS.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GuestController : ControllerBase
{
    private readonly IGuestService guestService;

    public GuestController(IGuestService guestService)
    {
        this.guestService = guestService;
    }

    [HttpGet]
    public  ActionResult GetAll ()
    {
        var guests = this.guestService.RetrieveAllGuests();
        
        return this.Ok(guests);
    }

    [HttpPost]
    public async ValueTask<ActionResult<Guest>> CreateGuest(Guest guest)
    {
        var res = await this.guestService.AddGuest(guest);
        
        return Ok(res);
    }
}