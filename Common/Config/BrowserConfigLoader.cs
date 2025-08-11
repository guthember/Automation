using Microsoft.Playwright;
using Newtonsoft.Json;

namespace Common.Config;

public class BrowserConfigLoader
{
    public dynamic Config { get; private set; }

    public BrowserConfigLoader(dynamic config)
    {
        Config = config;
    }

    public BrowserTypeLaunchOptions GetBrowserLaunchOptions()
    {
        var browserOptions = new BrowserTypeLaunchOptions();

        if (Config.browser.headless != null)
        {
            browserOptions.Headless = Config.browser.headless;
        }

        if (Config.browser.viewport != null)
        {
            browserOptions.Args = new[] { $"--window-size={Config.browser.viewport.width},{Config.browser.viewport.height}" };
        }

        return browserOptions;
    }
}