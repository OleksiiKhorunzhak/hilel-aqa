using Atata;
using TechTalk.SpecFlow;
using AtataSamples.SpecFlow.PageObjects;

namespace AtataSamples.SpecFlow.StepDefinitions;

[Binding]
public sealed class CommonSteps : Steps
{
    [Given(@"I am on DemoQA WebTable Page")]
    public static void GivenIAmOnHomePage() =>
        Go.To<DemoQAWebTablePage>();
}
