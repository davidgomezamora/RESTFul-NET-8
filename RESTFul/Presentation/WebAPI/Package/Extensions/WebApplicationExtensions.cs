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

            application.UseExceptionHandler();
        }
    }
}
