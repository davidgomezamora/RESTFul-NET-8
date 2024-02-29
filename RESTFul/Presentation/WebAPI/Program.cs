using Core.Application.Extensions;
using Presentation.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationLayer();
builder.Services.AddPresentationLayer();

var app = builder.Build();

app.AddPresentationLayer();

app.Run();
