using ConsoleApp.Data;
using ConsoleApp.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Test.Integration.Utils
{
    public class SandboxPersistTest : IDisposable
    {
        protected readonly AppDbContext DbContext;
        public SandboxPersistTest()
        {
            var connectionString = RandomConnectionString(Constants.ConnectionStrng);
            DbContext = AppDbContextFactory.Create(new SqlConnection(connectionString));
            MigrateToDatabaseLatestVersion(DbContext);
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }

        private string RandomConnectionString(string baseConnection)
        {
            var builder = new SqlConnectionStringBuilder(baseConnection);
            builder.InitialCatalog = $"{builder.InitialCatalog}-{Guid.NewGuid():N}";
            return builder.ConnectionString;
        }

        private void MigrateToDatabaseLatestVersion(AppDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
