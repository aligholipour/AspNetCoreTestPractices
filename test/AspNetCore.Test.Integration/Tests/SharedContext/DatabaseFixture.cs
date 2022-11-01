namespace AspNetCore.Test.Integration.Tests.SharedContext
{
    public class DatabaseFixture : IDisposable
    {
        public Guid RandomId { get; private set; }
        public DatabaseFixture()
        {
            RandomId = Guid.NewGuid();
        }

        public void Dispose()
        {
        }
    }
}