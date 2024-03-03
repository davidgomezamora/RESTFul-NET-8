using Core.Application.Extensions;
using Infraestructure.Persistence.Extensions;
using Infraestructure.Shared.Extensions;
using Presentation.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Layer Services
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddSharedInfraestructureLayer();
builder.Services.AddPresentationLayer();
#endregion

var app = builder.Build();

app.AddPresentationLayer();

app.Run();
