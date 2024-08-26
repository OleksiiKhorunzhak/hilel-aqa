namespace DifferentExamples;
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }

    public Car SetMake(string make)
    {
        Make = make;
        return this;
    }

    public Car SetModel(string model)
    {
        Model = model;
        return this;
    }

    public Car SetColor(string color)
    {
        Color = color;
        return this;
    }
}

[TestFixture]
public class FluentApiTestsCar
{

    [Test]
    public void CarTest()
    {
        var myCar = new Car();

        myCar.SetMake("Toyota")
             .SetModel("Camry")
             .SetColor("Blue");

        Console.WriteLine($"Make: {myCar.Make}, Model: {myCar.Model}, Color: {myCar.Color}");
    }
}

public abstract class PageObject<TOwner>
    where TOwner : PageObject<TOwner>
{
    public TOwner DoSomething()
    {
        // Perform some action
        return (TOwner)this;
    }
}

public abstract class Page<TOwner> : PageObject<TOwner>
    where TOwner : Page<TOwner>
{
    public TOwner Open()
    {
        // Open the page
        return (TOwner)this;
    }

    public TOwner Close()
    {
        // Close the page
        return (TOwner)this;
    }

    public TOwner NavigateTo(string url)
    {
        // Navigate to a URL
        return (TOwner)this;
    }
}

public class HomePage : Page<HomePage>
{
    public HomePage Login(string username, string password)
    {
        // Perform login action
        return this;
    }
}

public class SearchPage : Page<HomePage>
{
    public SearchPage Search(string query)
    {
        // Perform search action
        return this;
    }
}

public class NotAPage 
{
    public NotAPage Walk(int distance)
    {
        // Perform search action
        return this;
    }
}

[TestFixture]
public class FluentApiTests
{
    [Test]
    public void HomePageTest()
    {
        var homePage = new HomePage();

        homePage.Open()
                .Login("user", "pass")
                .NavigateTo("http://example.com")
                .DoSomething()
                .Close();

        var searchPage = new SearchPage();

        searchPage//.Open()
                .Search("fluent interfaces")
                .NavigateTo("http://example.com")
                .DoSomething()
                .Close();
    }

}
