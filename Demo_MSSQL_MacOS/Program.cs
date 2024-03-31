using Demo_MSSQL_MacOS.Brokers;
using Demo_MSSQL_MacOS.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StorageBroker>();

builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<IGuestService, GuestService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.Run();