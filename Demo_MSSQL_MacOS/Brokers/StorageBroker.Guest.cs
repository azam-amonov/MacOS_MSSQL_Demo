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
}