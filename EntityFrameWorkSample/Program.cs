using Microsoft.EntityFrameworkCore;
using EntityFrameworkSample.Data;
using EntityFrameworkSample.Services.CategoryService;
using EntityFrameworkSample.Services.Contract;
using EntityFrameworkSample.Services.ProductService;
using EntityFrameworkSample.Services.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SampleContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


builder.Services.AddScoped(typeof(IRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryReportRepository, CategoryReportRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();