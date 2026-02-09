using WebAPI.Configurantions;
using WebAPI.Services;
using WebAPI.Services.Impl;
using WebAPI.Repositorys.Impl;
using WebAPI.Repositorys;
using WebAPI.Hypermedia.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.AddSerilogLogging();

builder.Services.AddControllers(options => 
    {
        options.Filters.Add<HyperMediaFilter>();
     })
    .AddContentNegotiation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddRouteConfig();

builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddHATEOASConiguration();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);


builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IBookServices, BookSevicesImpl>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IFileServices, FileServicesImpl>();


builder.Services.AddScoped<IPersonRepository , PersonRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseCorsConfiguration();

app.MapControllers();

app.USeHATEOASRoutes();

app.UseSwaggerSpecification();

app.UseScalarConfiguration();

app.Run();
