namespace PlaywrigthSpecFlow.API.Models
{
    internal class UserToken
    {
        public string token { get; set; }

        public DateTime expires { get; set; }

        public string status { get; set; }
        public string result { get; set; }
    }
}
