using Demo_MSSQL_MacOS.Models;

namespace Demo_MSSQL_MacOS.Service;

public interface IGuestService
{
    ValueTask<Guest> AddGuest(Guest guest);
    IQueryable<Guest> RetrieveAllGuests();
    ValueTask<Guest> RetrieveGuestByIdAsync(Guid id);
    ValueTask<Guest> ModifierGuestAsync(Guest guest);
    ValueTask<Guest> RemoveGuestAsync(Guest guest);
}