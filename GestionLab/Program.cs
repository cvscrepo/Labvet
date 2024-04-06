
using GestionLab.DAL.DBContext;
using GestionLab.IOC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar dependencias 
builder.Services.InyectarDependencias(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    GestionlabContext context = scope.ServiceProvider.GetService<GestionlabContext>();
    context.Database.Migrate();
}


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
