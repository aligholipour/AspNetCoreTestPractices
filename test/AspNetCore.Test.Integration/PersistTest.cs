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
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
