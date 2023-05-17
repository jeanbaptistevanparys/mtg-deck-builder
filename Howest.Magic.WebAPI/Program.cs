using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1.1", new OpenApiInfo
    {
        Title = "Magic API version 1.1",
        Version = "v1.1",
        Description = "API to manage Magic"
    });
    o.SwaggerDoc("v1.5", new OpenApiInfo
    {
        Title = "Magic API version 1.5",
        Version = "v1.5",
        Description = "API to manage Magic"
    });
});

builder.Services.AddDbContext<MyDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("CardsDb")));
builder.Services
    .AddScoped<ICardRepository,
        SqlCardRepository>();


builder.Services.AddAutoMapper(typeof(CardsProfile));

builder.Services.AddApiVersioning(o => {
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("version"),
        new HeaderApiVersionReader("api-version"),
        new MediaTypeApiVersionReader("v"));
});

builder.Services.AddVersionedApiExplorer(
    options =>
    {
        // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
        // note: the specified format code will format the version as "'v'major[.minor][-status]"
        options.GroupNameFormat = "'v'VVV";

        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
        // can also be used to control the format of the API version in route templates
        options.SubstituteApiVersionInUrl = true;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1.1/swagger.json", "Magic API v1.1");
        c.SwaggerEndpoint("/swagger/v1.5/swagger.json", "Magic API v1.5");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();