using AngleSharp;

namespace AutomationTests.StepDefinitions;

[Binding]
[Scope(Feature = "Example.com első bekezdés ellenőrzése")]
public class ExampleFirstParagraphSteps
{
    private readonly ScenarioContext _ctx;

    public ExampleFirstParagraphSteps(ScenarioContext ctx) => _ctx = ctx;

    [Then(@"the first paragraph should contain ""(.*)""")]
    public void ThenTheFirstParagraphShouldContain(string expectedText)
    {
        var content = _ctx.Get<string>("content");
        var context = BrowsingContext.New(Configuration.Default);
        var document = context.OpenAsync(req => req.Content(content)).Result;
        var firstP = document.QuerySelector("p");

        Assert.That(firstP, Is.Not.Null, "Nem található <p> tag.");
        Assert.That(firstP.TextContent.Contains(expectedText), Is.True, $"Az első <p> tag nem tartalmazza a '{expectedText}' szöveget.");
    }
}