namespace NewTestAtataProject
{
    [Parallelizable(ParallelScope.Self)]
    public class UITestFixtureDemoQa
    {
        [SetUp]
        public void SetUp() =>
            AtataContext.Configure().Build();

        [TearDown]
        public void TearDown() =>
            AtataContext.Current?.Dispose();
    }
}
