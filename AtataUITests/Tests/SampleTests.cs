namespace AtataUITests.Tests
{
    public sealed class SampleTests : UITestFixture
    {
        [Test]
        public void SampleTest() =>
            Go.To<OrdinaryPage>(url: "https://atata.io/")
                .PageTitle.Should.Contain("Atata");
    }
}
