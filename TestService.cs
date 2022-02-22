using Microsoft.Extensions.Options;

namespace MultiApi
{
    public interface ITestService
    {
        string GetData();
    }
    class TestService : ITestService
    {
        public string GetData()
        {
            return nameof(TestService);
        }
    }
}