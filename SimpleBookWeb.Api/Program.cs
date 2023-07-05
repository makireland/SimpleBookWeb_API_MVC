using Microsoft.EntityFrameworkCore;
using SimpleBookWeb.BLL.InterfaceServices;
using SimpleBookWeb.BLL.Services;
using SimpleBookWeb.Infra.Context;
using SimpleBookWeb.Infra.InterfacesRepo;
using SimpleBookWeb.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<BookDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("SimpleBookWebDb")));

//Dependency injection Repo
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Dependency injection DTOs
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();


app.UseCors(cors =>
{
    cors.AllowAnyOrigin();
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<BookDbContext>();
//    dbContext.Database.Migrate();
//}

app.Run();
