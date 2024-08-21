using Microsoft.Playwright;
using System.Text.Json.Nodes;

namespace PlaywrigthUITests.Homework
{
    internal class ReplaceApiResponce : UITestFixture
    {
        [Test]
        public async Task ReplaceResponse()
        {
            await Page.RouteAsync("*/**/api/v1/fruits", async route =>
            {
                var response = await route.FetchAsync();
                var body = await response.BodyAsync();
                var jn = JsonNode.Parse(body);
                JsonArray ja = jn.AsArray();
                ja[1]["name"] = "MY NEW NAME";

                await route.FulfillAsync(new() { Response = response, Json = ja });

            });

            await Page.GotoAsync("https://demo.playwright.dev/api-mocking");

            await Assertions.Expect(Page.GetByText("MY NEW NAME")).ToBeVisibleAsync();
        }

        [Test]
        public async Task ReplaceAndRemoveFruits()
        {
            
            await Page.RouteAsync("*/**/api/v1/fruits", async route => {
                var response = await route.FetchAsync(); 
                var body = await response.BodyAsync();   
                var jn = JsonNode.Parse(body);           
                JsonArray ja = jn.AsArray();            
               
                for (int i = 0; i < ja.Count; i++)
                {
                    if (ja[i]["name"].ToString() == "Orange")
                    {
                        ja[i]["name"] = "LAST FRUIT";  

                        
                        while (ja.Count > i + 1)
                        {
                            ja.RemoveAt(i + 1);
                        }

                        break;
                    }
                }

                await route.FulfillAsync(new() { Response = response, Json = ja });
            });

            await Page.GotoAsync("https://demo.playwright.dev/api-mocking");

            await Assertions.Expect(Page.GetByText("LAST FRUIT")).ToBeVisibleAsync();
        }

    }
}
