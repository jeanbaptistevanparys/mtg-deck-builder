using Howest.MagicCards.MinimalAPI.Mapping;

const string commonPrefix = "/api";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMagicServices(builder.Configuration.GetSection("MongoDB"));


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var config = builder.Configuration;
var urlPrefix = config.GetSection("ApiPrefix").Value ?? commonPrefix;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMagicEndpoints(urlPrefix);

app.Run();