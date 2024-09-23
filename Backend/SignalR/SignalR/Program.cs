using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalR.EFModels;
using SignalR.HubConfig; // Ensure correct namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders", policyBuilder =>
    {
        policyBuilder
            .AllowAnyOrigin() // Allow any origin
            .AllowAnyHeader() // Allow any header
            .AllowAnyMethod(); // Allow any HTTP method
    });
});
builder.Services.AddDbContext<SignalrContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
);

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true; // Enable detailed errors
});

builder.Services.AddSignalR();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeaders");

app.UseAuthorization();

app.MapControllers();
app.UseHttpsRedirection();

// Map the SignalR hub to a route
app.MapHub<MyHub>("/toastr");

app.Run();
