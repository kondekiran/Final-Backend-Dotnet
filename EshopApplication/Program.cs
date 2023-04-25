using EshopApplication.DBContextLayer;
using EshopApplication.Interfaces;
using EshopApplication.ServiceLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EshopDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUsers, UsersServices>();
builder.Services.AddScoped<ICategories, CategoriesServices>();
builder.Services.AddScoped<IProducts, ProductServices>();
// builder.Services.AddScoped<ICart, CartServices>();
builder.Services.AddScoped<IOrders, OrdersServices>();
builder.Services.AddScoped<ICarts, CartsServices>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.WithOrigins("")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAngularApp");

app.MapControllers();

app.Run();
