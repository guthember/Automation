namespace API.Tests.StepDefinitions;

[Binding]
[Scope(Feature = "Example.com oldalon a H1 ellenőrzése")]
public class ExampleHeadingSteps
{
    private readonly ScenarioContext _ctx;

    public ExampleHeadingSteps(ScenarioContext ctx) => _ctx = ctx;

    [Then(@"the H1 should be ""(.*)""")]
    public void ThenTheH1ShouldBe(string expected)
    {
        // A HttpClientSteps betette a teljes HTML-t a "content" kulcsba
        var content = _ctx.Get<string>("content");

        const string open = "<h1>";
        const string close = "</h1>";

        var i1 = content.IndexOf(open, StringComparison.OrdinalIgnoreCase);
        Assert.That(i1, Is.GreaterThanOrEqualTo(0), "Nem található <h1> tag.");

        i1 += open.Length;
        var i2 = content.IndexOf(close, i1, StringComparison.OrdinalIgnoreCase);
        Assert.That(i2, Is.GreaterThanOrEqualTo(0), "Nem található </h1> tag.");

        var actual = content[i1..i2].Trim();
        Assert.That(actual,
            Is.EqualTo(expected),
            $"A H1-nek '{expected}'-nek kell lennie, de '{actual}' volt.");
    }
}