using Core.Application.Package.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infraestructure.Persistence.Package.Interceptors
{
    internal sealed class AuditngInterceptor(IDateTimeService dateTimeService) : SaveChangesInterceptor
    {
        private readonly IDateTimeService _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));

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
            Added(context.ChangeTracker.Entries().Where(x => x.State is EntityState.Added));
            Modified(context.ChangeTracker.Entries().Where(x => x.State is EntityState.Modified));
            Deleted(context.ChangeTracker.Entries().Where(x => x.State is EntityState.Deleted));
        }

        private static void Added(IEnumerable<EntityEntry> entities)
        {
            foreach (var entity in entities)
            {
                // Set entry audit
            }
        }

        private static void Modified(IEnumerable<EntityEntry> entities)
        {
            foreach (var entity in entities)
            {
                // Set entry audit
            }
        }

        private static void Deleted(IEnumerable<EntityEntry> entities)
        {
            foreach (var entity in entities)
            {
                // Set entry audit
            }
        }
    }
}
