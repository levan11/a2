using Lecture10_Gr2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// register services and dbcontext
// we added only this 4 lines
builder.Services.AddScoped<DbContext, BookDbContext>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddDbContext<BookDbContext>(opts =>
opts.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DefaultConnection")));



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
