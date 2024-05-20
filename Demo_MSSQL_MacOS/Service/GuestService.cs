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

    public async ValueTask<Guest> AddGuest(Guest guest) =>
        await this.storageBroker.InsertGuestAsync(guest);

    public IQueryable<Guest> RetrieveAllGuests() =>
        this.storageBroker.SelectAllGuests();

    public async ValueTask<Guest> RetrieveGuestByIdAsync(Guid id) =>
        await this.storageBroker.SelectGuestAsync(id);

    public async ValueTask<Guest> ModifierGuestAsync(Guest guest) =>
        await this.storageBroker.UpdateGuestAsync(guest);

    public async ValueTask<Guest> RemoveGuestAsync(Guest guest) =>
        await this.storageBroker.DeleteGuestAsync(guest);
}