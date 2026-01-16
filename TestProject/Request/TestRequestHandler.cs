using TestProject.Contract;

namespace TestProject.Request;

public class TestRequestHandler : IRequestHandler<TestRequest, string>
{
    public async Task<string> HandleAsync(TestRequest request)
    {
        return "Test";
    }
}