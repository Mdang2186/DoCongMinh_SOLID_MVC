using DoCongMinh_api.Data;
using DoCongMinh_api.Repositories;
using DoCongMinh_api.Repositories.Interfaces;
using DoCongMinh_api.Services;
using DoCongMinh_api.Services.Interfaces;
using DoCongMinh_api.Validators;
using DoCongMinh_api.Data;
using DoCongMinh_api.Repositories;
using DoCongMinh_api.Repositories.Interfaces;
using DoCongMinh_api.Services;
using DoCongMinh_api.Services.Interfaces;
using DoCongMinh_api.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
var conn = builder.Configuration.GetConnectionString("Default")!;
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conn));

// DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();

// CORS cho dev
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("dev", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("dev");

app.MapControllers();

app.Run();
