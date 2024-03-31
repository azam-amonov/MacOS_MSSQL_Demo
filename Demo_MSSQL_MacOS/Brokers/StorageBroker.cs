using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Demo_MSSQL_MacOS.Brokers;

public partial class StorageBroker : EFxceptionsContext ,IStorageBroker
{
    private readonly IConfiguration configuration;

    public StorageBroker(IConfiguration configuration)
    {
        this.configuration = configuration;
        this.Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = this.configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    public async ValueTask<T> InsertAsync<T>(T @object)
    {
        var broker = new StorageBroker(this.configuration);

        broker.Entry(@object).State = EntityState.Added;
        await broker.SaveChangesAsync();
        
        return @object;
    }
    
    private IQueryable<T> SelectAll<T>() where T : class
    {
        var broker = new StorageBroker(this.configuration);

        return broker.Set<T>();
    }
}