using PlaywrigthSpecFlow.API.Models;

namespace PlaywrigthSpecFlow.API.Features.Account
{
    internal class AccountPresetup
    {
        internal static string UserName = "userName1";
        internal static string Password = "Pa$$word1";
        public bool AccountCreated;
        
        public UserModel MainUser = new UserModel()
        {
            UserName = UserName,
            Password = Password
        };

        #region Setup
        public void AccountApiPresetup()
        {
            AccountsApi account = new AccountsApi("https://demoqa.com/");
            AccountCreated = account.AddUser(MainUser).Result;
        }
        #endregion
    }
}