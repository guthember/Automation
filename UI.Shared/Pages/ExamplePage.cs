namespace UI.Shared.Pages;

public class ExamplePage
{
    private readonly IPage _page;
    private const string Url = "http://example.com";

    public ExamplePage(IPage page) => _page = page;

    public async Task NavigateAsync() =>
        await _page.GotoAsync(Url, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.DOMContentLoaded
        });

    private ILocator Heading => _page.Locator("h1");

    public async Task<string> GetHeadingTextAsync() =>
        (await Heading.TextContentAsync())?.Trim() ?? string.Empty;
}