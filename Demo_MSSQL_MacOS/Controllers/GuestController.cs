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
    public  ActionResult GetAllGuests ()
    {
        var guests = this.guestService.RetrieveAllGuests();
        
        return this.Ok(guests);
    }

    [HttpPost]
    public async ValueTask<ActionResult<Guest>> PostGuestAsync(Guest guest)
    {
        var res = await this.guestService.AddGuest(guest);
        
        return Ok(res);
    }

    [HttpGet("guestId")]
    public async ValueTask<ActionResult<Guest>> GetGuestByIdAsync(Guid guestId)
    {
        var guest = await this.guestService.RetrieveGuestByIdAsync(guestId);
        
        return Ok(guest);
    }

    [HttpPut]
    public async ValueTask<ActionResult<Guest>> PutGuestAsync(Guest guest)
    {
        var result = await this.guestService.ModifierGuestAsync(guest);
        
        return Ok(result);
    }

    [HttpDelete]
    public async ValueTask<ActionResult<Guest>> DeleteGuestAsync(Guest guest)
    {
        var result = await this.guestService.RemoveGuestAsync(guest);
        
        return Ok(result);
    }
}