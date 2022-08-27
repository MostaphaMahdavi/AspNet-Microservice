using Order.Api.Extensions;
using FluentValidation.AspNetCore;
using Order.Services.Orders.Commands.Create;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/*
builder.Services.AddControllers().AddFluentValidation(option => {
    option.ImplicitlyValidateChildProperties = true;
    option.ImplicitlyValidateRootCollectionElements = true;    
   // option.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    option.RegisterValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
});
*/


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServiceRegistry();
builder.Services.AddDbContextExt(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddMessagingConfiguration(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

