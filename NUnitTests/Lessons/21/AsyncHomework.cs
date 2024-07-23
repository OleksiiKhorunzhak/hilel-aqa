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

    [Test]
    public async Task TestGetStringAsync()
    {
        // TODO: Uncomment and implement test so it pass
        var result = await GetStringAsync();
        Assert.That(result, Is.EqualTo("Hello, World!"));
    }

    [Test]
    public async Task TestGetNumberWithExceptionAsync()
    {
        // Verify that GetNumberWithExceptionAsync() throws InvalidOperationException
        var exception = Assert.ThrowsAsync<InvalidOperationException>(GetNumberWithExceptionAsync);

        // Verify that the exception message is "An error occurred while fetching the number."
        Assert.That(exception.Message, Is.EqualTo("An error occurred while fetching the number."));
    }

}