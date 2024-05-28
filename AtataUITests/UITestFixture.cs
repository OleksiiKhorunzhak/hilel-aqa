namespace AtataUITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class UITestFixture
    {
        [SetUp]
        public void SetUp() =>
            AtataContext.Configure().UseChrome().Build();

        [TearDown]
        public void TearDown() =>
        AtataContext.Current?.Dispose();
    }
}
