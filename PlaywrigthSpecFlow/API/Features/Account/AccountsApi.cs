using Newtonsoft.Json;
using PlaywrigthSpecFlow.API.Models;
using System.Net;
using System.Net.Http.Headers;
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

        public async Task<string> AddUserGetId(UserModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("Account/v1/User", content);

            if (response.StatusCode != HttpStatusCode.Created)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<User>(responseContent);

            Console.WriteLine("User created successfully.");
            return createdUser.userID;
        }

        public async Task<string?> GenerateToken(UserModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = await Client.PostAsync("Account/v1/GenerateToken", content);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseToken = JsonConvert.DeserializeObject<UserToken>(responseContent);

            return responseToken.token;
        }

        public async Task<HttpResponseMessage> GetUserById(string userId, string token)
        {
            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Get, Client.BaseAddress + "Account/v1/User/" + userId))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                return await Client.SendAsync(requestMessage);
            }
        }

        public async Task DeleteAccountByID(string ID)
        {
            //TODO: implement
        }
    }
}

