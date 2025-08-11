namespace AutomationTests.TestFiles;

[TestFixture]
public class Test_02 : BaseTest
{
    protected override string GetTestConfigFileName()
    {
        return "Test_02.json";
    }

    [Test]
    public async Task ExampleDotCom_HasCorrectH1()
    {
        // Arrange
        await using var context = await _browser.NewContextAsync();
        var page        = await context.NewPageAsync();
        var examplePage = new ExamplePage(page);

        // Act
        await examplePage.NavigateAsync();
        var paragraphText = await examplePage.GetParagraphTextAsync();

        // Assert
        //Assert.That(paragraphText, Is.EqualTo("This domain is for use in illustrative examples in documents. You may use this\n    domain in literature without prior coordination or asking for permission."),"nem ugyanaz a tartalom!");
        Assert.That(paragraphText, Does.Contain("This domain is for use in illustrative examples"), "Nem tartalmazza!");
    } 
}