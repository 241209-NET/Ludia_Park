using Microsoft.EntityFrameworkCore;
using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Repository;
using LudisFoodCourt.Api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add dbcontext and connect it to connection string
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodCourtConnect")));

// Learn more about co nfiguring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Inject the proper services
// whenever IVendorService is called, pass in concrete impl of VendorService.
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IDinerService, DinerService>();
builder.Services.AddScoped<IDinerRepository, DinerRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();



// Add our controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


/*
DataContext is the object representation of our sql db.
*/

