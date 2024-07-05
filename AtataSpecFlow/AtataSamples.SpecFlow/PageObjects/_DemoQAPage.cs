using Atata;
namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("https://demoqa.com/")]
    public abstract class _DemoQAPage<TOwner> : Page<TOwner>
        where TOwner : _DemoQAPage<TOwner>
    {

    }
}
