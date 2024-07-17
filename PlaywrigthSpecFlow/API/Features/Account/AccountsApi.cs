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


		public async Task<string> GetToken(UserModel model)
		{
			var json = JsonConvert.SerializeObject(model);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await Client.PostAsync("/Account/v1/GenerateToken", content);

			if (response.StatusCode != HttpStatusCode.OK)
			{
				Console.WriteLine($"Error: {response.StatusCode}");
				return null;
			}

			var responseContent = await response.Content.ReadAsStringAsync();
			var generatedToken = JsonConvert.DeserializeObject<Token>(responseContent);

			Console.WriteLine("Token generated successfully.");
			return generatedToken.token;
		}

		public async Task DeleteAccountByID(string ID, string token)
        {
			//HttpRequestMessage deleteMessage = new HttpRequestMessage(HttpMethod.Delete, $"https://demoqa.com/Account/v1/User/{ID}");
			//deleteMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
			//HttpResponseMessage response = await Client.SendAsync(deleteMessage);
			Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
			HttpResponseMessage response = await Client.DeleteAsync($"/Account/v1/User/{ID}");

			if (response.StatusCode != HttpStatusCode.OK)
			{
				Console.WriteLine($"Error: {response.StatusCode}");
			}

			else
			{
				Console.WriteLine($"User with id = {ID} was deleted sucessfuly");
			}
		}
    }
}

