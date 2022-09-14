using ConsoleApp;

namespace AspNetCore.Test.Unit.TaxCalculate.TestDoubles
{
    public class StupRaxRepository : ITaxRepository
    {
        public double GetCurrentTaxRate()
        {
            return 9;
        }
    }
}
