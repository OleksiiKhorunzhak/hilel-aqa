using Newtonsoft.Json;
using PlaywrigthSpecFlow.API.Models;
using System.Net;
using System.Text;

namespace PlaywrigthSpecFlow.API.Features.Account
{
    internal class AccountsApi
    {
        private readonly HttpClient Client;

        public AccountsApi(string baseAddress)
        {
            Client = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public async Task<bool> AddUser(UserModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("Account/v1/User", content);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("User created successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return false;
            }
        }
    }
}

