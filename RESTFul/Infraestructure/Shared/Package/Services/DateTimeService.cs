using Core.Application.Package.Interfaces;

namespace Infraestructure.Shared.Package.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
