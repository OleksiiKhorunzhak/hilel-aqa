namespace Lesson21;

public class AsyncHomework
{
    public async Task<string> GetStringAsync()
    {
        await Task.Delay(500);
        return "Hello, World!";
    }

    public async Task<int> GetNumberWithExceptionAsync()
    {
        await Task.Delay(1000);
        throw new InvalidOperationException("An error occurred while fetching the number.");
    }

    // TODO: Uncomment and implement test so it pass
    [Test]
    public async Task TestGetStringAsync()
    {
        var result = await GetStringAsync(); 
         Assert.That(result, Is.EqualTo("Hello, World!"));
    }

    // TODO: Verify that GetNumberWithExceptionAsync() throws InvalidOperationException
    // and that exception message is "An error occurred while fetching the number."
    [Test]
    public void TestGetNumberWithExceptionAsync()
    {
        var exception = Assert.ThrowsAsync<InvalidOperationException>(GetNumberWithExceptionAsync);
        Assert.That(exception.Message, Is.EqualTo("An error occurred while fetching the number."));
    }

}