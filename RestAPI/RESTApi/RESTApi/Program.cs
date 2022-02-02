using Microsoft.EntityFrameworkCore;
using RESTApi;
using RESTApi.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPerson, PersonService>();
builder.Services.AddDbContext<ApiDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
