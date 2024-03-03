using Microsoft.Extensions.Options;
using Presentation.WebAPI.Package.Middlewares;
using Presentation.WebAPI.Package.Middlewares.Options;

namespace Presentation.WebAPI.Package.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void AddPresentationLayerBase(this WebApplication application)
        {
            bool viewException = false;

            // Configure the HTTP request pipeline.
            if (application.Environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI();

                //viewException = true;
            }

            application.UseHttpsRedirection();

            application.UseAuthorization();

            application.MapControllers();

            application.UseErrorHandlingMiddleware(new()
            {
                ViewException = viewException
            });
        }

        public static void UseErrorHandlingMiddleware(this WebApplication application, ErrorHandlerMiddlewareOptions options)
        {
            application.UseMiddleware<ErrorHandlerMiddleware>(Options.Create(options));
        }
    }
}
