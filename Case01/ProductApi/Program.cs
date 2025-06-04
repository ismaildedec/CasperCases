#region Using
using Microsoft.OpenApi.Models;
using ProductApi.Services;
#endregion

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product API",
        Version = "v1",
        Description = "Mock ürün listeleme ve filtreleme servisi."
    });
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddScoped<IProductService, ProductService>();
#endregion

var app = builder.Build();

#region Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthorization();
app.MapControllers();
#endregion

#region Startup Message
Console.WriteLine("----------------------------------------");
Console.WriteLine("Product API başlatıldı!");
Console.WriteLine("Swagger UI: /swagger");
Console.WriteLine("----------------------------------------");
#endregion

app.Run();
