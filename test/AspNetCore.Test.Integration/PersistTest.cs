using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace AspNetCore.Test.Integration
{
    public class PersistTest<T> : IDisposable where T : DbContext, new()
    {
        private TransactionScope _scope;
        protected T DbContext;
        protected PersistTest()
        {
            _scope = new TransactionScope();
            DbContext = new T();
        }
        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.DbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Deleted;
        }
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
