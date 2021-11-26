using Locations.Data;
using Locations.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyDbContext>(options =>
   options.UseMySql(builder.Configuration.GetConnectionString("DbLocation"),
       new MySqlServerVersion(new Version(8, 0))
));

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<SearchAddressService>();
app.MapGrpcService<AddressService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
