using Common.Config;
using Newtonsoft.Json;

namespace AutomationTests.TestFiles;

public class BaseTest
{
    protected IPlaywright _playwright = null!;
    protected IBrowser _browser = null!;
    protected IPage _page = null!;
    protected BrowserConfigLoader _browserConfigLoader = null!;
    protected dynamic _defaultConfig = null!;
    

    public BaseTest()
    {
        var defaultConfigFilePath = Path.Combine("ConfigFiles", "TestFiles", "DefaultConfig.json");
        _defaultConfig = LoadConfig(defaultConfigFilePath);
    }

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        var configFilePath = Path.Combine("ConfigFiles", "TestFiles", GetTestConfigFileName());
        var customConfig = File.Exists(configFilePath) ? LoadConfig(configFilePath) : null;

        var finalConfig = customConfig ?? _defaultConfig;

        _browserConfigLoader = new BrowserConfigLoader(finalConfig);
        var browserOptions = _browserConfigLoader.GetBrowserLaunchOptions();

        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(browserOptions);
        _page = await _browser.NewPageAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDownAsync()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    protected virtual string GetTestConfigFileName()
    {
        return "DefaultTestConfig.json";
    }
    
    private dynamic LoadConfig(string configFilePath)
    {
        var jsonConfig = File.ReadAllText(configFilePath);
        return JsonConvert.DeserializeObject<dynamic>(jsonConfig);
    }
}