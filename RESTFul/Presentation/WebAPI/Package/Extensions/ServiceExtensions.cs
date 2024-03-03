namespace Presentation.WebAPI.Package.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPresentationLayerBase(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
