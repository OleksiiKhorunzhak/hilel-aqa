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
        [AfterFeature(@"ICreateAccountByAPI")]
        public static async Task WhenICleanupAccountByAPI(FeatureContext featureContext)
        {
            var presetup = featureContext.Get<AccountPresetup>("AccountApiPresetup");
            // presetup.
        }
    }
}
