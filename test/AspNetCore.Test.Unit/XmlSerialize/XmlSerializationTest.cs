using FluentAssertions;

namespace AspNetCore.Test.Unit.XmlSerialize
{
    public class XmlSerializationTest
    {
        [Fact]
        public void serialize_empty_tag_empty_object()
        {
            // Arrange
            var customer = new Customer();
            var expected = "<Customer></Customer>";

            //Act
            var serialize = SerializeProvider.Serialize(customer);

            //Assert
            serialize.Should().Be(expected);
        }

        [Fact]
        public void serialize_empty_string_for_null_valuse()
        {
            var serialize = SerializeProvider.Serialize(null);

            serialize.Should().BeEmpty();
        }

        [Fact]
        public void serialize_flat_object()
        {
            var person = new Person("John", "Doe");

            var expected = "<Person>" +
                               "<FirstName>John</FirstName>" +
                               "<LastName>Doe</LastName>" +
                           "</Person>";

            var serialize = SerializeProvider.Serialize(person);

            serialize.Should().Be(expected);
        }

        private class Customer
        {
        }
        private class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}