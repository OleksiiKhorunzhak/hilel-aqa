using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AtataSamples.SpecFlow.Api.Features.Account
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
            if (_featureContext.TryGetValue("AccountApiPresetup", out var presetupObj) && presetupObj is AccountPresetup presetup)
            {
                Assert.That(presetup.UserId, Is.Not.Null, "Account not created");
            }
        }

        //TODO: add cleanup
        [AfterFeature(@"ICreateAccountByAPI")]
        public static void WhenICleanupAccountByAPI(FeatureContext featureContext)
        {
            if (featureContext.TryGetValue("AccountApiPresetup", out var presetupObj) && presetupObj is AccountPresetup presetup)
            {

                //presetup.

            }
        }
    }
}
