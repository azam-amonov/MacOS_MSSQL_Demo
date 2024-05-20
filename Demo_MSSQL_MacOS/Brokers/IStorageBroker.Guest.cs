using Demo_MSSQL_MacOS.Models;

namespace Demo_MSSQL_MacOS.Brokers;

public partial interface IStorageBroker
{
    ValueTask<Guest> InsertGuestAsync(Guest guest);
    IQueryable<Guest> SelectAllGuests();
    ValueTask<Guest> SelectGuestAsync(Guid guestId);
    ValueTask<Guest> UpdateGuestAsync(Guest guest);
    ValueTask<Guest> DeleteGuestAsync(Guest guest);
}