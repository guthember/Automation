namespace AutomationTests.TestFiles;

[TestFixture]
public class Test_01 : BaseTest
{
    protected override string GetTestConfigFileName()
    {
        return "Test_01.json";
    }

    [Test]
    public async Task ExampleDotCom_HasCorrectH1()
    {
        // Arrange
        await using var context = await _browser.NewContextAsync();
        var examplePage = new ExamplePage(_page);

        // Act
        await examplePage.NavigateAsync();
        var headingText = await examplePage.GetHeadingTextAsync();

        // Assert
        Assert.That(headingText, Is.EqualTo("Example Domain"),"a példaoldal <h1> tartalma pontosan ‘Example Domain’");
    }
}