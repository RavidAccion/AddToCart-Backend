using Add2Cart.Db_Context;
using Add2Cart.Services;
using Add2Cart.Interface;
using Add2Cart.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection serviceCollection = builder.Services.AddDbContext<DataBase>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultCS")
        );
});



builder.Services.AddControllers();
builder.Services.AddScoped<Icategory, CategoryService>();
builder.Services.AddScoped<Iproducts, ProductClass>();
builder.Services.AddScoped<Ilogin, LoginServices>();
builder.Services.AddScoped<Icart, CartService>();
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
app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
