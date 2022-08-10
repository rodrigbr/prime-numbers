using FluentValidation.Results;
using MediatR;
using Prime.Numbers.Application.CommandHandlers;
using Prime.Numbers.Application.Commands;
using Prime.Numbers.Application.Contracts;
using Prime.Numbers.Application.Helpers;
using Prime.Numbers.Application.Implementations;
using Prime.Numbers.Domain.Entites;

var _allowedOriginsDevelopment = new HashSet<string>()
{
    "http://localhost:4200",
    "http://localhost:4200/"
};

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MediatR
builder.Services.AddMediatR(typeof(WebApplication).Assembly);

//Services
builder.Services.AddScoped<IPrimeNumberApplicationService, PrimeNumberApplicationService>();

// Domain - Commands
builder.Services.AddScoped<IRequestHandler<CalculatePrimeNumbersCommand, OperationResult<PrimeNumbersResult>>, CalculatePrimeNumbersCommandHandler>();

builder.Services.AddCors(options =>
{
    string[] allowedOrigins = new string[_allowedOriginsDevelopment.Count];
    _allowedOriginsDevelopment.CopyTo(allowedOrigins);

    options.AddPolicy("SiteCorsPolicy", cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowCredentials();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
        cors.WithOrigins("http://localhost:4200").AllowAnyMethod();
    });
});

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.AllowAnyHeader();
    builder.AllowCredentials();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prime.Numbers.WebApi v1"));
}

//app.UseHttpsRedirection();

app.UseCors("ApiCorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
