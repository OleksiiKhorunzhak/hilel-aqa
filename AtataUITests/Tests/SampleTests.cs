namespace AtataUITests.Tests
{
    public sealed class SampleTests : UITestFixture
    {
        [Test]
        public void SampleTest() =>
            Go.To<OrdinaryPage>()
                .PageTitle.Should.Contain("Atata");
    }
}
