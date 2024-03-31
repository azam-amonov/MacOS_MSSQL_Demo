using Demo_MSSQL_MacOS.Brokers;
using Demo_MSSQL_MacOS.Models;

namespace Demo_MSSQL_MacOS.Service;

public class GuestService : IGuestService
{
    private readonly StorageBroker storageBroker;

    public GuestService(StorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public async ValueTask<Guest> AddGuest(Guest guest)
    {
        return await this.storageBroker.InsertGuestAsync(guest);
    }

    public IQueryable<Guest> RetrieveAllGuests()
    {
        return this.storageBroker.SelectAllGuests();
    }
}