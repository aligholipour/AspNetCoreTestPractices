using AspNetCore.Test.Unit.TaxCalculate.TestDoubles;
using ConsoleApp;
using FluentAssertions;

namespace AspNetCore.Test.Unit.TaxCalculate
{
    public class TaxtCalculatorTest
    {
        [Fact]
        public void tax_is_subtrack_from_salary()
        {
            var repository = new StupRaxRepository();
            var service = new TaxService(repository);

            var salaryWithoutTax = service.CalculateSalary(1000000);

            salaryWithoutTax.Should().Be(910000);
        }
    }
}
