using DevEncurtaUrl.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
     );

});

var connectionString = builder.Configuration.GetConnectionString("DevEncurtaURL");

//builder.Services.AddDbContext<DevEncurtaUrlDbContext>(o => o.UseInMemoryDatabase("DevEncurtaDb")); //Banco em memoria

builder.Services.AddDbContext<DevEncurtaUrlDbContext>(o => o.UseSqlServer("DevEncurtaDb"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
