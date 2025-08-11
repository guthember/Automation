
using AngleSharp;
using AngleSharp.Dom;

namespace AutomationTests.StepDefinitions;

[Binding]
[Scope(Feature = "Example.com oldalon a H1 ellenőrzése")]
public class ExampleHeadingSteps
{
    private readonly ScenarioContext _ctx;

    public ExampleHeadingSteps(ScenarioContext ctx) => _ctx = ctx;

    [Then(@"the H1 should be ""(.*)""")]
    public void ThenTheH1ShouldBe(string expected)
    {
        var content = _ctx.Get<string>("content");
        var context = BrowsingContext.New(Configuration.Default);
        var document = context.OpenAsync(req => req.Content(content)).Result;
        var h1 = document.QuerySelector("h1");
        Assert.That(h1, Is.Not.Null, "Nem található <h1> tag.");
        Assert.That(h1.TextContent.Trim(), Is.EqualTo(expected), $"A H1-nek '{expected}'-nek kell lennie.");
    }
}