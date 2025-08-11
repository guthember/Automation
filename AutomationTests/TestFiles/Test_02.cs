namespace AutomationTests.TestFiles;

[TestFixture]
public class Test_02 : BaseTest
{
    protected override string GetTestConfigFileName()
    {
        return "Test_02.json";
    }

    [Test]
    public async Task ExampleDotCom_HasCorrectParagrahp()
    {
        // Arrange
        await using var context = await _browser.NewContextAsync();
        var examplePage = new ExamplePage(_page);

        // Act
        await examplePage.NavigateAsync();
        var paragraphText = await examplePage.GetParagraphTextAsync();

        // Assert
        Assert.That(paragraphText, Does.Contain("This domain is for use in illustrative examples"), "Nem tartalmazza!");
    } 
}