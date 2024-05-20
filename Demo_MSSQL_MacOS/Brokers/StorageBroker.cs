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
    
    public IQueryable<T> SelectAll<T>() where T : class
    {
        var broker = new StorageBroker(this.configuration);

        return broker.Set<T>();
    }

    public async ValueTask<T> SelectAsync<T>(params object[] item) where T : class =>
        await FindAsync<T>(item);

    public async ValueTask<T> UpdateAsync<T>(T @object)
    {
        var broker = new StorageBroker(this.configuration);
        broker.Entry(@object).State = EntityState.Modified;
        await broker.SaveChangesAsync();

        return @object;
    }

    public async ValueTask<T> DeleteAsync<T>(T @object)
    {
        var broker = new StorageBroker(this.configuration);
        broker.Entry(@object).State = EntityState.Deleted;
        await broker.SaveChangesAsync();
        
        return @object;
    }
}