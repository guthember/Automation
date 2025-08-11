namespace AutomationTests.StepDefinitions;

[Binding]
public class HttpClientSteps
{
    private readonly ScenarioContext _ctx;

    public HttpClientSteps(ScenarioContext ctx) => _ctx = ctx;

    [Given(@"I have an HTTP client configured to ""(.*)""")]
    public void GivenIHaveAnHttpClientConfiguredTo(string baseUrl)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            // ha akarod, itt állíthatod a Timeout-ot
        };
        _ctx["client"] = client;
    }

    [When(@"I request the path ""(.*)""")]
    public async Task WhenIRequestThePath(string path)
    {
        var client = _ctx.Get<HttpClient>("client");
        var response = await client.GetAsync(path);
        _ctx["response"] = response;
        _ctx["content"]  = await response.Content.ReadAsStringAsync();
    }
}