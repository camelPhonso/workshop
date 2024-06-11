using Book.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IBookContext, BookContext>(options => options.UseInMemoryDatabase("BookDb"));
builder.Services.AddScoped<IBookContext, BookContext>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  using (var db = scope.ServiceProvider.GetService<BookContext>()!)
  {
    db.Database.EnsureCreated();
  }
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute("default", "api/[controller]/[action]");

app.UseHttpsRedirection();

app.Run();
