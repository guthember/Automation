namespace UI.Tests;

[TestFixture]
public class ExampleTests
{
    private IPlaywright _playwright = null!;
    private IBrowser    _browser    = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser    = await _playwright.Chromium.LaunchAsync(new()
        {
            Headless = false
        });
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDownAsync()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
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
        var headingText = await examplePage.GetHeadingTextAsync();

        // Assert
        Assert.That(headingText, Is.EqualTo("Example Domain"),"a példaoldal <h1> tartalma pontosan ‘Example Domain’");
    }
}