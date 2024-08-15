using Core.Application.Extensions;
using Infraestructure.Persistence.Extensions;
using Infraestructure.Shared.Extensions;
using Presentation.WebAPI.Extensions;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.AddPresentationLayer();
#endregion

#region Services
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddSharedInfraestructureLayer();
builder.Services.AddPresentationLayer();
#endregion

#region Applications
var app = builder.Build();

app.AddPresentationLayer();

app.Run();
#endregion
