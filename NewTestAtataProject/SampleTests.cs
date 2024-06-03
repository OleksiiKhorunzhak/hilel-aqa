namespace NewTestAtataProject
{
    public sealed class SampleTests : UITestFixtureDemoQa
    {
        [Test]
        public void SampleTest() =>
            Go.To<OrdinaryPage>()
                .PageTitle.Should.Contain("DEMOQA");
    }
}
