using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using SweetMeet.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Add EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SweetMeet API",
        Version = "v1",
        Description = "API for SweetMeet application"
    });
});

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();          
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SweetMeet API v1");
        // Optional: open Swagger UI at root
        // c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();