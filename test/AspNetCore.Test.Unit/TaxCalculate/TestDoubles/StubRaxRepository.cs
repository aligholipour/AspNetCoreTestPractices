using ConsoleApp;

namespace AspNetCore.Test.Unit.TaxCalculate.TestDoubles
{
    public class StubRaxRepository : ITaxRepository
    {
        private double _taxRate;
        private StubRaxRepository() { }

        public static StubRaxRepository CreateNewStub()
        {
            return new StubRaxRepository();
        }

        public StubRaxRepository WhichReturnsTaxRateAs(double taxRate)
        {
            _taxRate = taxRate;
            return this;
        }

        public double GetCurrentTaxRate()
        {
            return _taxRate;
        }
    }
}
