using Core.Application.Extensions;
using Infraestructure.Persistence.Extensions;
using Infraestructure.Shared.Extensions;
using Presentation.WebAPI.Extensions;

#region Layer Builder
var builder = WebApplication.CreateBuilder(args);

builder.AddPresentationLayer();
#endregion

#region Layer Services
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddSharedInfraestructureLayer();
builder.Services.AddPresentationLayer();
#endregion

#region Layer Applications
var app = builder.Build();

app.AddPresentationLayer();

app.Run();
#endregion
