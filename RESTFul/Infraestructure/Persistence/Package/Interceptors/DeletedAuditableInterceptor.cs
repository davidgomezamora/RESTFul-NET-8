using Core.Application.Package.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infraestructure.Persistence.Package.Interceptors
{
    internal sealed class DeletedAuditableInterceptor : SaveChangesInterceptor
    {
        private readonly IDateTimeService _dateTimeService;

        public DeletedAuditableInterceptor(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is not null)
            {
                Audit(eventData.Context);
            }

            InterceptionResult<int> interceptionResult = await base.SavingChangesAsync(eventData, result, cancellationToken);

            return interceptionResult;
        }

        private static void Audit(DbContext context)
        {
            IEnumerable<EntityEntry> entityEntries = context.ChangeTracker.Entries().Where(x => x.State is EntityState.Deleted);

            foreach (var entityEntry in entityEntries)
            {
                // Set entry audit
            }
        }
    }
}
