using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Howest.MagicCards.DAL.Models.MyDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("CardsDb")));
builder.Services
    .AddScoped<Howest.MagicCards.DAL.Repositories.ICardRepository,
        Howest.MagicCards.DAL.Repositories.SqlCardRepository>();


builder.Services.AddAutoMapper(new Type[]
    {
        typeof(Howest.MagicCards.Shared.Mappings.CardsProfile)
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();