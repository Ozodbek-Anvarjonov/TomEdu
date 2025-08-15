using TomEdu.Api.Extensions;
using TomEdu.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    //.AddApplication()
    .AddPersistence(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

app.Run();