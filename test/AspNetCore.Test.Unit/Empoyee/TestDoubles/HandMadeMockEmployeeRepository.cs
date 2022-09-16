using ConsoleApp.Employee;

namespace AspNetCore.Test.Unit.Empoyee.TestDoubles
{
    public class HandMadeMockEmployeeRepository : IEmployeeRepository
    {
        Dictionary<string, MethodCall> _methodCalls = new Dictionary<string, MethodCall>();

        public void Create(Employee employee)
        {
            if (_methodCalls.ContainsKey(nameof(Create)))
                _methodCalls[nameof(Create)].IncreaseCallTimes();
            else
                _methodCalls.Add(nameof(Create), new MethodCall(employee, 1));
        }
        public MethodCall GetCall(string methodName)
        {
            return _methodCalls[methodName];
        }
    }

    public class MethodCall
    {
        public MethodCall(object argument, int callTime)
        {
            PassedArgument = argument;
            CallTimes = callTime;
        }
        public object PassedArgument { get; set; }
        public int CallTimes { get; set; }

        public void IncreaseCallTimes()
        {
            this.CallTimes++;
        }
    }
}
