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
        // TODO: Verify that GetNumberWithExceptionAsync() throws InvalidOperationException
        // and that exception message is "An error occurred while fetching the number."

        try
        {
            await GetNumberWithExceptionAsync();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("An error occurred while fetching the number."));
        }
    }

}