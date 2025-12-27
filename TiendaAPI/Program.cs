using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Mappings;
using TiendaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

//Configuracion de BD
var connectionString = builder.Configuration.GetConnectionString("CadenaSQL");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

//Registro de servicios 
builder.Services.AddScoped<IProductoService, ProductoService>();

//Mapper
//Configuracion Manual de mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
//Objeto mapper
IMapper mapper = mapperConfig.CreateMapper();
//Registro del mapper en el contenedor de servicios
builder.Services.AddSingleton(mapper);

// Add services to the container.

builder.Services.AddControllers();
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
