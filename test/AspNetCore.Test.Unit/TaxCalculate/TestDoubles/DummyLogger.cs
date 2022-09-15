using ConsoleApp;

namespace AspNetCore.Test.Unit.TaxCalculate.TestDoubles
{
    public class DummyLogger : ILogger
    {
        public void Error(string message)
        {
        }

        public void Info(string message)
        {
        }
    }
}
