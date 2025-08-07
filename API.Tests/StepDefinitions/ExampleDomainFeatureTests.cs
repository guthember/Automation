using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace API.Tests.StepDefinitions;

[Binding]
public class ExampleDomainSteps
{
    private HttpClient _client = null!;
    private HttpResponseMessage _response = null!;
    private string _content = null!;

    [Given(@"I have an HTTP client configured to ""(.*)""")]
    public void GivenIHaveAnHttpClientConfiguredTo(string baseUrl)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            // Timeout = TimeSpan.FromSeconds(10)
        };
    }

    [When(@"I request the path ""(.*)""")]
    public async Task WhenIRequestThePath(string path)
    {
        _response = await _client.GetAsync(path);
        _content  = await _response.Content.ReadAsStringAsync();
    }

    [Then(@"the HTTP status code should be (.*)")]
    public void ThenTheHttpStatusCodeShouldBe(int expectedStatus)
    {
        Assert.That((int)_response.StatusCode,
            Is.EqualTo(expectedStatus),
            $"Várt státuszkód: {expectedStatus}, kapott: {(int)_response.StatusCode}");
    }

    [Then(@"the response should contain ""(.*)""")]
    public void ThenTheResponseShouldContain(string expectedFragment)
    {
        Assert.That(_content,
            Does.Contain(expectedFragment),
            $"A válasznak tartalmaznia kell: {expectedFragment}");
    }
}