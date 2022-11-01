namespace AspNetCore.Test.Integration.Tests.SharedContext.ClassFixtures
{
    public class SharedDatabaseClassFixtureTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        public SharedDatabaseClassFixtureTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            var randomGuid = _fixture.RandomId; // randomGuid = 55f1dbdc-24dc-4425-aef9-a10b7b24ae8a;
        }

        [Fact]
        public void Test2()
        {
            var randomGuid = _fixture.RandomId; // randomGuid = 55f1dbdc-24dc-4425-aef9-a10b7b24ae8a;
        }
    }

    public class SharedDatabaseClassFixtureTest2 : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        public SharedDatabaseClassFixtureTest2(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            var randomGuid = _fixture.RandomId; // randomGuid = 4416f29a-99ae-4d96-bf36-88fe10d9ea83;
        }
    }
}