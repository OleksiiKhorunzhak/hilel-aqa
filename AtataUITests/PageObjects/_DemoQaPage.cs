namespace AtataUITests.PageObjects
{
    //Home page:
    [Url("https://demoqa.com/")]
    [VerifyTitle("DEMOQA")]
    public abstract class DemoQAPage<TOwner> : Page<TOwner>
        where TOwner : DemoQAPage<TOwner>
    {
    }
}