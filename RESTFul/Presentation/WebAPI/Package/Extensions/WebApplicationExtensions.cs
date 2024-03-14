﻿using Presentation.WebAPI.Package.Middlewares;
using Presentation.WebAPI.Package.Middlewares.Options;

namespace Presentation.WebAPI.Package.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void AddPresentationLayerBase(this WebApplication application)
        {
            // Configure the HTTP request pipeline.
            if (application.Environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI();
            }

            application.UseHttpsRedirection();

            application.UseAuthorization();

            application.MapControllers();

            application.UseErrorHandlingMiddleware(new()
            {
                DevelopmentEnvironment = application.Environment.IsDevelopment()
            });
        }

        public static void UseErrorHandlingMiddleware(this WebApplication application, ExceptionHandlingMiddlewareOptions options)
        {
            application.UseMiddleware<ExceptionHandlingMiddleware>(Microsoft.Extensions.Options.Options.Create(options));
        }
    }
}
