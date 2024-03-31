using Demo_MSSQL_MacOS.Models;

namespace Demo_MSSQL_MacOS.Service;

public interface IGuestService
{
    ValueTask<Guest> AddGuest(Guest guest);
    public IQueryable<Guest> RetrieveAllGuests();
}