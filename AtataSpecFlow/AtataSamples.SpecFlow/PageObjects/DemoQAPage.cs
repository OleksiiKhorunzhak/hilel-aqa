using Atata;
namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("https://demoqa.com/")]
    public abstract class DemoQAPage<TOwner> : Page<TOwner>
        where TOwner : DemoQAPage<TOwner>
    {

    }
}
