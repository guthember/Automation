using Common.Config;
using Newtonsoft.Json;

namespace AutomationTests.TestFiles;

public class BaseReqnrollTest : BaseTest
{
    public BaseReqnrollTest() : base()
    {
    }

    protected override string GetTestConfigFileName()
    {
        string scenarioName = TestContext.CurrentContext.Test.Name;
        string testName = scenarioName.Split(new string[] { " - " }, StringSplitOptions.None)[0];
        Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>Test name: {testName}<<<<<<<<<<<<<<<<<<<<<<");
        return $"{testName}.json";
    }
}