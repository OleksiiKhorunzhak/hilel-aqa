
using System.Text;
using Microsoft.Playwright;


namespace Lesson18HW;

public class ExampleTest
{

    public IPage Page { get; set; }
    private IBrowser browser;

    [SetUp]
    public async Task Setup()
    {
        var storagefile = "../../../playwright/.auth/Lesson18HW.json";
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });

        var fileinfo = new FileInfo(storagefile);
        

        if (!fileinfo.Exists)
        {
            Directory.CreateDirectory(fileinfo.Directory.FullName);
            using (FileStream fs = File.Create(storagefile))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("");
                fs.Write(info, 0, info.Length);
            }
        }



        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            
            StorageStatePath = storagefile,
            ViewportSize = new ViewportSize
            {

                Width = 1920,
                Height = 1080
                
            },

        }); 
      
        Page = await context.NewPageAsync();
     
        await Page.GotoAsync("https://courses.ultimateqa.com/enrollments");
        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        if (Page.Url.EndsWith("users/sign_in"))
        {
            await Page.GetByPlaceholder("Email").ClickAsync();
            await Page.GetByPlaceholder("Email").FillAsync("Astolfo@gmail.com");
            await Page.GetByPlaceholder("Email").PressAsync("Tab");
            await Page.GetByPlaceholder("Password").FillAsync("qazwsxedc");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();
            await Assertions.Expect(Page.GetByRole(AriaRole.Link, new() { Name = "My Dashboard" })).ToBeVisibleAsync();
            await context.StorageStateAsync(new()
            {
                Path = storagefile
            });
        }
    }
    [Test]
    public async Task Login()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "View more courses" }).ClickAsync();
        await Page.GetByPlaceholder("Search").ClickAsync();
        await Page.GetByPlaceholder("Search").FillAsync("Selenium");
        await Page.GetByPlaceholder("Search").PressAsync("Enter");

        var elements = Page.Locator(".card-name");
        Assert.IsNotNull(elements, "There are no elements with class .class name");
        var count = await elements.CountAsync();
        for (int i = 0; i < count; i++)
        {
            var element = elements.Nth(i);
            await Assertions.Expect(element).ToContainTextAsync("Selenium");
        }

        await Page.GetByRole(AriaRole.Link, new() { Name = "My Dashboard" }).ClickAsync();
        await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome back, Astolfo R!" })).ToBeVisibleAsync();
        await Page.GetByLabel("Toggle menu").ClickAsync();

       




    }


}