using ConsoleApp.Data;
using ConsoleApp.Infrastructure;
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace AspNetCore.Test.Integration.Utils
{
    public abstract class PersistTest : IDisposable
    {
        private TransactionScope _scope;
        protected AppDbContext DbContext;
        protected PersistTest()
        {
            _scope = new TransactionScope();
            DbContext = AppDbContextFactory.Create(new SqlConnection(Constants.ConnectionStrng));
        }

        public void Dispose()
        {
            DbContext.Dispose();
            _scope.Dispose();
        }
    }
}
