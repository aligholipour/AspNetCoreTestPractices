namespace AspNetCore.Test.Integration.Tests.SharedContext.CollectionFixtures
{
    [Collection("CollectionFixture")]
    public class FirstSharedDatabaseCollectionFixtureTests
    {
        private readonly DatabaseFixture _fixture;
        public FirstSharedDatabaseCollectionFixtureTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            var randomGuid = _fixture.RandomId; // randomGuid = f1c74b4a-6e89-4525-9c42-7eca302458a9;
        }

        [Fact]
        public void Test2()
        {
            var randomGuid = _fixture.RandomId; // randomGuid = f1c74b4a-6e89-4525-9c42-7eca302458a9;
        }
    }

    [Collection("CollectionFixture")]
    public class SecondSharedDatabaseCollectionFixtureTests
    {
        private readonly DatabaseFixture _fixture;
        public SecondSharedDatabaseCollectionFixtureTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            var randomGuid = _fixture.RandomId; // randomGuid = f1c74b4a-6e89-4525-9c42-7eca302458a9;
        }
    }
}
