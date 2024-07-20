using PlaywrigthSpecFlow.API.Features.Account;
using TechTalk.SpecFlow;

namespace PlaywrigthSpecFlow.Features.Account
{
    [Binding]
    public class AccountSteps
    {
        private readonly FeatureContext _featureContext;

        public AccountSteps(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        [BeforeFeature(@"ICreateAccountByAPI")]
        public static async Task WhenICreateAccountByAPI(FeatureContext featureContext)
        {
            AccountPresetup accountPresetup = new AccountPresetup();
            await accountPresetup.AccountApiPresetup();
            featureContext["AccountApiPresetup"] = accountPresetup;
        }

        [Then(@"I get success status code from API")]
        public void ThenISeeSuccessStatusCode()
        {
            var presetup = _featureContext.Get<AccountPresetup>("AccountApiPresetup");
            Assert.That(presetup.UserId, Is.Not.Null, "Account not created");
        }

        //TODO: add cleanup
        [AfterFeature(@"IDeleteAccountByAPI")]
        public static async Task WhenICleanupAccountByAPI(FeatureContext featureContext)
        {
            var presetup = featureContext.Get<AccountPresetup>("AccountApiPresetup");
            await presetup.AccountApiCleanup();
        }

        [Then(@"I get message that account deleted after cleanup")]
        public async Task ThenIGetMessageThatAccountDeletedAsync()
        {
            var presetup = _featureContext.Get<AccountPresetup>("AccountApiPresetup");
            await presetup.AccountApiCleanup();
            Assert.That(presetup.UserId, Is.Not.Null, "Account is not deleted");
        }
    }
}
