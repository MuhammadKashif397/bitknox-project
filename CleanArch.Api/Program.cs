using Microsoft.EntityFrameworkCore;
using MyApp.Application.Services;
using MyApp.Domain.Interface;
using MyApp.Infrastrusture.Data;
using MyApp.Infrastrusture.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("BlogDbContext")
        ?? throw new InvalidOperationException(
            "Connection string : 'BlogDbContext' not found"));
});
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
