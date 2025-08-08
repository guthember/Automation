using HtmlAgilityPack;

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
        var content = _ctx.Get<string>("content");
        var doc = new HtmlDocument();
        doc.LoadHtml(content);
        var h1 = doc.DocumentNode.SelectSingleNode("//h1");
        Assert.That(h1, Is.Not.Null, "Nem található <h1> tag.");
        Assert.That(h1.InnerText.Trim(), Is.EqualTo(expected), $"A H1-nek '{expected}'-nek kell lennie.");
    }
}