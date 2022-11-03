using AspNetCore.Test.Unit.TaxCalculate.TestDoubles;
using ConsoleApp.Tax;
using FluentAssertions;

namespace AspNetCore.Test.Unit.TaxCalculate
{
    public class TaxtCalculatorTest
    {
        [InlineData(1000000, 9, 910000)]
        [InlineData(1000000, 9.5, 905000)]
        [InlineData(1000000, 0, 1000000)]
        //[MemberData(nameof(TaxCalculateValues))] Using MemeberData
        [Theory]
        public void tax_is_subtrack_from_salary(long salary, double taxRate, double expected)
        {
            var repository = StubRaxRepository.CreateNewStub().WhichReturnsTaxRateAs(taxRate);
            var service = new TaxService(repository, new DummyLogger());

            var salaryWithoutTax = service.CalculateSalary(salary);

            salaryWithoutTax.Should().Be(expected);
        }

        public static IEnumerable<object[]> TaxCalculateValues
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { 1000000, 9, 910000 },
                    new object[] { 1000000, 9.5, 905000 },
                    new object[] { 1000000, 0, 1000000 }
                };
            }
        }
    }
}
