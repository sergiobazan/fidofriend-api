using API.Mapper;
using Domain;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserInfrastructure, UserInfrastructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<IPetInfrastructure, PetInfrastructure>();
builder.Services.AddScoped<IPetDomain, PetDomain>();

builder.Services.AddScoped<IClinicalRecordInfrastructure, ClinicalRecordInfrastructure>();
builder.Services.AddScoped<IClinicalRecordDomain, ClinicalRecordDomain>();

builder.Services.AddScoped<IServiceInfrastructure, ServiceInfrastructure>();
builder.Services.AddScoped<IServiceDomain, ServiceDomain>();

builder.Services.AddScoped<IServiceVetInfrastructure, ServiceVetInfrastructure>();
builder.Services.AddScoped<IServiceVetDomain, ServiceVetDomain>();

builder.Services.AddScoped<IMeetingInfrastructure, MeetingInfrastructure>();
builder.Services.AddScoped<IMeetingDomain, MeetingDomain>();

builder.Services.AddScoped<IProductInfrastructure, ProductInfrastructure>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("FidoDbConnection"));
});

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(RequestToModel));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
