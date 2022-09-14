namespace ConsoleApp
{
    public class TaxService
    {
        private readonly ITaxRepository _taxRepository;
        public TaxService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public double CalculateSalary(double salary)
        {
            var taxRate = _taxRepository.GetCurrentTaxRate();
            var valueToSubtract = taxRate * salary / 100;
            return salary - valueToSubtract;
        }
    }
}
