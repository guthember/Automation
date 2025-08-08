namespace AutomationTests.StepDefinitions;

[Binding]
public class ResponseValidationSteps
{
    private readonly ScenarioContext _ctx;

    public ResponseValidationSteps(ScenarioContext ctx) => _ctx = ctx;

    [Then(@"the HTTP status code should be (.*)")]
    public void ThenTheHttpStatusCodeShouldBe(int expectedStatus)
    {
        var response = _ctx.Get<HttpResponseMessage>("response");
        Assert.That((int)response.StatusCode,
            Is.EqualTo(expectedStatus),
            $"Várt státuszkód: {expectedStatus}, kapott: {(int)response.StatusCode}");
    }

    [Then(@"the response should contain ""(.*)""")]
    public void ThenTheResponseShouldContain(string expectedFragment)
    {
        var content = _ctx.Get<string>("content");
        Assert.That(content,
            Does.Contain(expectedFragment),
            $"A válasznak tartalmaznia kell: {expectedFragment}");
    }
}