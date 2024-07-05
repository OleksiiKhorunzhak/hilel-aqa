using PlaywrigthSpecFlow.API.Models;

namespace PlaywrigthSpecFlow.API.Features.Account
{
    internal class AccountPresetup
    {
        internal static string UserName = "Usr" + GetCurrentTimestamp();
        internal static string Password = "Pa$$word1";
        internal bool AccountCreated;

        internal UserModel MainUser = new UserModel()
        {
            userName = UserName,
            password = Password
        };

        #region Setup
        internal void AccountApiPresetup()
        {
            AccountsApi account = new AccountsApi("https://demoqa.com/");
            AccountCreated = account.AddUser(MainUser).Result;
        }
        #endregion
        #region HelperMethods
        internal static string GetCurrentTimestamp()
        {
            DateTime currentTimestamp = DateTime.UtcNow;

            string timestamp = currentTimestamp.ToString("u");

            timestamp = Regex.Replace(timestamp, @"\D", "");

            return timestamp;
        }
        #endregion
    }
}