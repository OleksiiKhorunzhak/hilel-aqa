namespace Lesson21;

public class AsyncTests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public async Task AsyncEach()
    {
        var start = DateTime.Now;
        Console.WriteLine("Start.");

        await BoilWaterAsync();
        await FryEggsAsync();
        await ToastBreadAsync();

        Console.WriteLine("Finish. Elapsed: " + (DateTime.Now - start));
    }

    [Test]
    public async Task AsyncTestWithAwait()
    {
        var start = DateTime.Now;
        Console.WriteLine("Start.");

        await MakeBreakfastAsync();
        
        Console.WriteLine("Finish. Elapsed: " + (DateTime.Now - start));

    }

    [Test]
    public async Task AsyncEachNoAwait()
    {
        var start = DateTime.Now;
        Console.WriteLine("Start.");

        BoilWaterAsync();
        FryEggsAsync();
        ToastBreadAsync();

        Console.WriteLine("Finish. Elapsed: " + (DateTime.Now - start));
    }

    [Test]
    public void AsyncTestWithoutAwait()
    {
        var start = DateTime.Now;
        Console.WriteLine("Start.");

        MakeBreakfastAsync();
        Thread.Sleep(1500);

        Console.WriteLine("Finish. Elapsed: " + (DateTime.Now - start));
    }

    private static async Task MakeBreakfastAsync()
    {
        Task waterTask = BoilWaterAsync();
        Task eggsTask = FryEggsAsync();
        Task toastTask = ToastBreadAsync();

        await Task.WhenAll(waterTask, eggsTask, toastTask);
    }

    private static async Task BoilWaterAsync()
    {
        Console.WriteLine("Boiling water...");
        await Task.Delay(3000); // Simulate time taken to boil water asynchronously
        Console.WriteLine("Water boiled.");
    }

    private static async Task FryEggsAsync()
    {
        Console.WriteLine("Frying eggs...");
        await Task.Delay(2000); // Simulate time taken to fry eggs asynchronously
        Console.WriteLine("Eggs fried.");
    }

    private static async Task ToastBreadAsync()
    {
        Console.WriteLine("Toasting bread...");
        await Task.Delay(1000); // Simulate time taken to toast bread asynchronously
        Console.WriteLine("Bread toasted.");
    }

}