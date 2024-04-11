using MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GetOrderingByIdQueryHandler>();
builder.Services.AddScoped<GetOrderingByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderingCommandHandler>();
builder.Services.AddScoped<UpdateOrderingCommandHandler>();
builder.Services.AddScoped<RemoveOrderingCommandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();



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
