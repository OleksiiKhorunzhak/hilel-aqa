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
		Assert.That("Hello, World!", Is.EqualTo(result));
	}

    [Test]
    public async Task TestGetNumberWithExceptionAsync()
    {
        // TODO: Verify that GetNumberWithExceptionAsync() throws InvalidOperationException
        // and that exception message is "An error occurred while fetching the number."
        Assert.Multiple(()=>
        {
            Assert.ThrowsAsync<InvalidOperationException>(() => GetNumberWithExceptionAsync());
            
            var exeption = Assert.ThrowsAsync<InvalidOperationException>(() => GetNumberWithExceptionAsync());
            string expected_message = "An error occurred while fetching the number.";
			Assert.That(exeption.Message, Is.EqualTo(expected_message));
        });

	}

}