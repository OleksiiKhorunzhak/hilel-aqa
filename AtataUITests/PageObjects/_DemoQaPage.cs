namespace AtataUITests.PageObjects
{
    //Home page:
    [Url("https://demoqa.com/")]
    public abstract class DemoQAPage<TOwner> : Page<TOwner>
        where TOwner : DemoQAPage<TOwner>
    {
    }
}