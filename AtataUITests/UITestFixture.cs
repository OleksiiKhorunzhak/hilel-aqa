namespace AtataUITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class UITestFixture
    {
        [SetUp]
        public void SetUp() =>
            AtataContext.Configure()
                .UseChrome()
                    .WithArguments("start-maximized")
                    .WithArtifactsAsDownloadDirectory()
                .Build();

        [TearDown]
        public void TearDown() =>
            AtataContext.Current?.Dispose();
    }
}
