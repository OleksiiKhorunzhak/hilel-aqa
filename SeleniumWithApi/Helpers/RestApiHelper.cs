using OpenQA.Selenium;
using System.Net;

namespace SeleniumWithApi.Helpers
{
    public class RestApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly CookieContainer _cookieContainer;

        public RestApiHelper()
        {
            _cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer,
                UseCookies = true
            };

            _httpClient = new HttpClient(handler);
        }

        // Method to send GET requests
        public async Task<HttpResponseMessage> SendGetRequestAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            return await _httpClient.SendAsync(request);
        }

        // Method to send POST requests with JSON payload
        public async Task<HttpResponseMessage> SendPostRequestAsync(string url, HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };
            return await _httpClient.SendAsync(request);
        }

        // Method to read Set-Cookie header from the response
        public string GetSetCookieHeader(HttpResponseMessage response)
        {
            if (response.Headers.TryGetValues("Set-Cookie", out var cookieHeaders))
            {
                return string.Join("; ", cookieHeaders);
            }
            return null;
        }

        // Method to set cookies in the browser (Selenium WebDriver)
        public void SetCookiesInBrowser(IWebDriver driver, Uri uri)
        {
            var cookies = _cookieContainer.GetCookies(uri);

            foreach (System.Net.Cookie cookie in cookies)
            {
                var existingCookie = driver.Manage().Cookies.GetCookieNamed(cookie.Name);
                if (existingCookie != null)
                {
                    driver.Manage().Cookies.DeleteCookie(existingCookie);
                }

                var seleniumCookie = new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, cookie.Expires, cookie.Secure, cookie.HttpOnly, null);
                
                driver.Manage().Cookies.AddCookie(seleniumCookie);
            }
        }
    }
}
