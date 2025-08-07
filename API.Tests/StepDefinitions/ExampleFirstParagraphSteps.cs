namespace API.Tests.StepDefinitions;

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
        var startTag = "<p>";
        var endTag   = "</p>";

        var start = content.IndexOf(startTag,
            System.StringComparison.OrdinalIgnoreCase);
        Assert.That(start, Is.GreaterThanOrEqualTo(0),
            "Nem található <p> nyitó tag a válaszban.");

        start += startTag.Length;
        var end = content.IndexOf(endTag, start,
            System.StringComparison.OrdinalIgnoreCase);
        Assert.That(end, Is.GreaterThanOrEqualTo(0),
            "Nem található </p> záró tag a válaszban.");

        var paragraph = content[start..end].Trim();
        Assert.That(paragraph,
            Does.Contain(expectedText),
            $"A bekezdés tartalma: '{paragraph}', de vártuk: '{expectedText}'.");
    }
}