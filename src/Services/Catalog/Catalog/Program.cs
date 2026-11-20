
using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);
//Register services
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CatalogDb")!);
}).UseLightweightSessions();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();
