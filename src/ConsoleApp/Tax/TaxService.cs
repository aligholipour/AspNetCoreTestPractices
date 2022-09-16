namespace ConsoleApp.Tax
{
    public class TaxService
    {
        private readonly ITaxRepository _taxRepository;
        private readonly ILogger _logger;
        public TaxService(ITaxRepository taxRepository, ILogger logger)
        {
            _taxRepository = taxRepository;
            _logger = logger;
        }

        public double CalculateSalary(double salary)
        {
            var taxRate = _taxRepository.GetCurrentTaxRate();
            var valueToSubtract = taxRate * salary / 100;

            var calculateTaxSalary = salary - valueToSubtract;

            _logger.Info($"calculate successfull: {calculateTaxSalary}");

            return calculateTaxSalary;
        }
    }
}
