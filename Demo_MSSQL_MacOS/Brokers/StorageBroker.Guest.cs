using Demo_MSSQL_MacOS.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_MSSQL_MacOS.Brokers;

public partial class StorageBroker
{
    public DbSet<Guest> Guest { get; set; }
    
    public async ValueTask<Guest> InsertGuestAsync(Guest guest) =>
        await InsertAsync(guest);

    public IQueryable<Guest> SelectAllGuests() => 
        SelectAll<Guest>();

    public async ValueTask<Guest> SelectGuestAsync(Guid guestId) =>
        await SelectAsync<Guest>(guestId);

    public async ValueTask<Guest> UpdateGuestAsync(Guest guest) =>
    await UpdateAsync(guest);
    
    public async ValueTask<Guest> DeleteGuestAsync(Guest guest) =>
        await DeleteAsync(guest);
}