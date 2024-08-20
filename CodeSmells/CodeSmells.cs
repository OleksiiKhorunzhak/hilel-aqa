using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TechTalk.SpecFlow;
using Microsoft.Playwright;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using CodeSmells.PRCommentsExamples;

namespace CodeSmells
{
    [Binding]
    internal class CodeSmells
    {

        OrderPage orderPage = new();
        SearchPage searchPage = new();
        CartPage cartPage = new();
        ChromeDriver Driver = new();

        // Smell 1: Magic numbers
        [Then("Order total is going to be correct")]
        public void ThenOrderTotalsCorrect()
        {
            Assert.That(orderPage.GetOrderTotal(), Is.EqualTo(2.33));
        }

        // Smell 1: Magic numbers. How to improve
        [Then("Order total is correct")]
        public void ThenOrderTotalsCorrectFix1()
        {
            // The same expected result on all test Envs. Never changes
            // TODO: Move to constants
            var expectedOrderTotal = 2.33;
            Assert.That(orderPage.GetOrderTotal(), Is.EqualTo(expectedOrderTotal), "Order Total is not equal to expected value");
        }

        // or to read such values from test data provider
        [Then("Order total is correct")]
        public void ThenOrderTotalsCorrectFix2()
        {
            var expectedOrderTotal = Data.Get("Order Total").Value;
            Assert.That(orderPage.GetOrderTotal(), Is.EqualTo(decimal.Parse(expectedOrderTotal)), "Order Total is not equal to expected value");
        }

        // Smell 2: Too long method (more than 30 lines)
        public IEnumerable<string> GetVerifiedSearchResults(string text)
        {
            if (text.Equals(string.Empty))
            {
                throw new Exception("Input parameter 'text' must not be empty");
            }

            if (text.Length > 100)
            {
                throw new Exception("Too long search text");
            }

            var searchResults = searchPage.GetSearchResultHeaders(text);

            foreach (var searchResult in searchResults)
            {
                if (searchResult == null)
                {
                    throw new Exception("Search result is null");
                }
            }

            var searchResultTexts = searchResults.Select(el => el.Text);

            foreach (var searchResultText in searchResultTexts)
            {
                if (searchResultText.Equals(string.Empty))
                {
                    throw new Exception("Search result text is empty");
                }

                if (searchResultText.Length > 100)
                {
                    throw new Exception(string.Format("Search result text is too long: '{0}'", searchResultText));
                }
            }

            return searchResultTexts;
        }

        // Smell 2: Too long method (more than 30 lines). How to improve. 
        /* 
         * You may find next recomendations:
         * 1) Function length 1-8 lines
         * 2) Less than 20 lines
         * 3) Less than 30 lines
         * 4) Fit into one screen
         */
        public IEnumerable<string> GetVerifiedSearchResultsFix(string text)
        {
            ValidateText(text);

            var searchResults = searchPage.GetSearchResultHeaders(text);

            if (searchResults.Any(sr => sr == null))
            {
                throw new Exception("Search result is null");
            }

            var searchResultTexts = searchResults.Select(el => el.Text);

            foreach (var searchResultText in searchResultTexts)
            {
                ValidateText(searchResultText);
            }

            return searchResultTexts;
        }

        private void ValidateText(string text)
        {
            if (text.Equals(string.Empty))
            {
                throw new Exception("Text must not be empty");
            }

            if (text.Length > 100)
            {
                throw new Exception(string.Format("Too long text '{0}'", text));
            }
        }


        // Smell 3: Too many parameters (more than 5)
        public List<string> GetArticles(string searchText, int page, int startLine, int endLine, int minLength, int maxLength)
        {
            var pageArticles = searchPage.GetArticles(searchText, page);
            var limitedArticles = SelectArticles(pageArticles, startLine, endLine);
            var limitedArticlesByLength = SelectArticlesByLength(limitedArticles, minLength, maxLength);

            return limitedArticlesByLength.Select(a => a.Text).ToList();
        }

        private IEnumerable<IWebElement> SelectArticlesByLength(object limitedArticles, int minLength, int maxLength)
        {
            throw new NotImplementedException();
        }

        private object SelectArticles(object pageArticles, int minLine, int maxLine)
        {
            throw new NotImplementedException();
        }

        // Smell 3: Too many parameters (more than 5). How to improve
        /* 
         * You may find next recomendations:
         * 1) Number of function parameters 1-2, maximum 3
         * 2) Up to 5
         */

        public class SearchCriteria
        {
            public string SearchText { get; set; }
            public int PageNumber { get; set; }
            public int MinLine { get; set; }
            public int MaxLine { get; set; }
            public int MinLength { get; set; }
            public int MaxLength { get; set; }
        }

        public List<string> GetArticlesFix(SearchCriteria searchCriteria)
        {
            var pageArticles = searchPage.GetArticles(searchCriteria.SearchText, searchCriteria.PageNumber);
            var limitedArticles = SelectArticles(pageArticles, searchCriteria.MinLine, searchCriteria.MaxLine);
            var limitedArticlesByLength = SelectArticlesByLength(limitedArticles, searchCriteria.MinLength, searchCriteria.MaxLength);

            return limitedArticlesByLength.Select(a => a.Text).ToList();
        }


        // Smell 4: Gulp exceptions
        public IWebDriver GetWebDriver()
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            IWebDriver myChrome = null;
            try
            {
                myChrome = new ChromeDriver(".\\Drivers");
            }
            catch { }

            return myChrome;
        }

        // Smell 4: Gulp exceptions. How to improve
        public IWebDriver GetWebDriverFix()
        {
            var chromeDriverDir = ".\\Drivers";
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            IWebDriver myChrome = null;
            try
            {
                myChrome = new ChromeDriver(chromeDriverDir);
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to initiate chromedriver. Check that chromedriver.exe is present in the folder '{0}'", chromeDriverDir);
                throw;
            }

            return myChrome;
        }

        // Smell 5: Fail as quick as possible
        public string SearchInGoogle(string text)
        {
            var searchResult = searchPage.FindInGoogle(text);

            if (text == null)
                throw new Exception("Input parameter 'text' must not be null");

            return searchResult;
        }

        // Smell 5: Fail as quick as possible. How to improve
        public string SearchInGoogleFix(string text)
        {
            if (text == null)
                throw new Exception("Input parameter 'text' must not be null");

            return searchPage.FindInGoogle(text);
        }

        // Smell 6: Method name does not match to implementation (and incorrect naming in general)
        public IEnumerable<string> RemoveHeaders(string i)
        {
            IEnumerable<IWebElement> div = searchPage.GetHeaders(i);
            IEnumerable<string> copy = div.Select(lambda => lambda.Text);

            return copy;
        }

        // Smell 6: Method name does not match to implementation (and incorrect naming in general). How to improve
        public IEnumerable<string> GetHeaderTextsByPattern(string pattern)
        {
            IEnumerable<IWebElement> headerElements = searchPage.GetHeaders(pattern);
            IEnumerable<string> headertexts = headerElements.Select(webElement => webElement.Text);

            return headertexts;
        }

        // Smell 7: Many cycles and conditions
        public void ClickActiveFavourite()
        {
            var allFavourite = Driver.FindElements(By.CssSelector(".favourite")).ToArray();

            if (allFavourite.Length > 0)
            {
                if (allFavourite.Length > 1)
                {
                    var fewFavourite = allFavourite.Take(allFavourite.Length / 2);

                    foreach (var favourite in fewFavourite)
                    {
                        if (Favorite.Available(favourite.Text))
                        {
                            var categories = Driver.FindElements(By.CssSelector(".category"));
                            foreach (var category in categories)
                            {
                                if (category.Text.Equals(favourite))
                                {
                                    Driver.FindElement(By.CssSelector(".favourite")).Click();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("One of favourites is not available: " + favourite.Text);
                        }
                    }
                }
                else
                {
                    if (allFavourite.First().Enabled)
                    {
                        Driver.FindElement(By.CssSelector(".favourite")).Click();
                    }
                    else
                    {
                        throw new Exception("Single available favourite is not active");
                    }
                }
            }
            else
            {
                throw new Exception("There are no favourite available");
            }
        }

        // Smell 7: Many cycles and conditions. How to improve
        public void ClickActiveFavouriteFix()
        {
            var allFavourite = Driver.FindElements(By.CssSelector(".favourite")).ToArray();

            if (allFavourite.Length == 0)
                throw new Exception("There are no favourite available");

            if (allFavourite.Length == 1)
            {
                ClickSingleFavorite(allFavourite.First());
                return;
            }

            var fewFavourite = allFavourite.Take(allFavourite.Length / 2);

            foreach (var favourite in fewFavourite)
            {
                if (Favorite.Available(favourite.Text) && GetCategoryNames().Contains(favourite.Text))
                {
                    Driver.FindElement(By.CssSelector(".favourite")).Click();
                    return;
                }
                else
                {
                    Console.WriteLine("One of favourites is not available: " + favourite.Text);
                }
            }
        }

        private void ClickSingleFavorite(IWebElement favourite)
        {
            if (Favorite.Available(favourite.Text))
            {
                favourite.Click();
            }
            else
            {
                throw new Exception("Single available favourite is not active");
            }
        }

        private IEnumerable<string> GetCategoryNames()
        {
            var categories = Driver.FindElements(By.CssSelector(".category"));
            return categories.Select(c => c.Text);
        }

        // Smell 8: Middle man (method just calls another method)
        public bool IsValidationMessagePresent(string message)
        {
            return ContainsValidationMessage(message);
        }

        public bool ContainsValidationMessage(string message)
        {
            return GetValidationMessages().Contains(message);
        }

        // Smell 8: Middle man (method just calls another method). How to improve

        // Remove IsValidationMessagePresent(). It could became "middle man" after some refactoring
        // Replace calls of IsValidationMessagePresent() with ContainsValidationMessage() in all other code

        public bool ContainsValidationMessageFix(string message)
        {
            return GetValidationMessages().Contains(message);
        }

        private IEnumerable<string> GetValidationMessages()
        {
            throw new NotImplementedException();
        }

        // Smell 8: Middle man (method just calls another method). Another example
        [When(@"Proceeding checkout without terms and conditions accepted")]
        public void WhenProceedingCheckoutWithoutTermsAndConditionsAccepted()
        {
            When("I make checkout");
        }


        [When("I make checkout")]
        public void WhenIMakeCheckout()
        {
            CheckoutPage.MakeCheckout();
        }

        // Smell 8: Middle man (method just calls another method). Another example. How to improve
        [When("I make checkout")]
        [When(@"Proceeding checkout without terms and conditions accepted")]
        public void WhenIMakeCheckoutFix()
        {
            CheckoutPage.MakeCheckout();
        }

        // Smell 9: Extra comments

        //Returns Order comment
        public string GetOrderComment()
        {
            return Driver.FindElement(By.Id("comment")).GetAttribute("value");
        } // end of GetOrderComment()

        // Is Go To Checkout available
        public bool chaval()
        {
            return Driver.FindElement(By.Id("goToCheckout")).Enabled;
        }

        // Smell 9: Extra comments. How to improve

        public string GetOrderCommentFix()
        {
            return Driver.FindElement(By.Id("comment")).GetAttribute("value");
        }

        public bool CanGoToCheckout()
        {
            return Driver.FindElement(By.Id("goToCheckout")).Enabled;
        }


        // Smell 10: Code in reserve (YAGNI — You aren't gonna need it)

        private readonly By _updateCartBtn = By.Id("updateCartButton");
        private readonly By _clearCartBtn = By.Id("emptyCartButton");
        private readonly By _cancelBtn = By.Id("cancelButton"); // <-- this selector is never used in code, but precent on the Page
        private readonly By _note = By.Id("clear");

        public void UpdateCart()
        {
            Driver.FindElement(_updateCartBtn).Click();
        }

        public virtual void ClearCart() // <-- this function is never called, but functionality exists
        {
            Driver.FindElement(_clearCartBtn).Click();
        }

        public virtual void ClearNote(int lineNumber)
        {
            Driver.FindElement(_note).Clear();
            UpdateCart();
        }

        // Smell 10: Code in reserve. How to improve - remove extra code, do not spend time to write it


        // Smell 11: "Then" without "Assert"

        [Then("Order total is going to be correct")]
        public void ThenOrderTotalsCorrect2()
        {
            orderPage.IsOrderTotalsCorrect(Data.Get("expectedOrderTotal").Value); //regardless of True/False result test will be "green"
        }

        // Smell 11: "Then" without "Assert". How to improve

        [Then("Order total is correct")]
        public void ThenOrderTotalsCorrect2Fix()
        {
            Assert.That(orderPage.IsOrderTotalsCorrect(Data.Get("expectedOrderTotal").Value), Is.True, "Order total is incorrect");
        }

        // above implementation will work, but in case of failure output is 
        // "Order total is incorrect. Expected: True, but was: False"
        // it is better to write like this:

        [Then("Order total is correct")]
        public void ThenOrderTotalsCorrect3Fix()
        {
            Assert.That(orderPage.GetOrderTotal(), Is.EqualTo(decimal.Parse(Data.Get("expectedOrderTotal").Value)));
            // in this case failure output will be like "Expected: 4.55, but was: 4.54"
        }

        // Smell 12: "Assert" inside "foreach" without verification that collection is not empty

        [Then(@"Added products are shown in Cart")]
        public void ThenAddedProductsAreShownInCart()
        {
            var products = Driver.FindElements(By.Id("product"));
            foreach (var product in products)
            {
                Assert.IsTrue(cartPage.HasProduct(product),
                    string.Format("'{0}' product was not shown in the Cart", product));
            }
        }


        // Smell 12: "Assert" inside "foreach" without verification that collection is not empty. How to improve

        [Then(@"Added products are shown in Cart")]
        public void ThenAddedProductsAreShownInCartFix()
        {
            var products = Driver.FindElements(By.Id("product"));
            // Without this Assert tst will always pass if "Products" collection is empty
            Assert.IsTrue(products.Any(), "There are no products in the Cart at all");

            foreach (var product in products)
            {
                Assert.IsTrue(cartPage.HasProduct(product),
                    string.Format("'{0}' product was not shown in the Cart", product));
            }
        }


        // Smell 13: Duplicated code (DRY — Don't repeat yourself)
        public string FindInGoogle(string text)
        {
            var searchInput = By.CssSelector("input[name='q']");
            var searchBtn = By.CssSelector("input[name='btnK']");
            var waitDriver = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = searchInput;
            waitDriver.Until(driver => driver.FindElement(element).Displayed && driver.FindElement(element).Enabled);

            Driver.FindElement(searchInput).SendKeys(text);
            element = searchBtn;
            waitDriver.Until(driver => driver.FindElement(element).Displayed && driver.FindElement(element).Enabled);
            Driver.FindElement(searchBtn).Click();
            return Driver.FindElement(By.CssSelector("h3")).Text;
        }

        public IEnumerable<IWebElement> GetSearchResultHeaders(string text)
        {
            var searchInput = By.CssSelector("input[name='q']");
            var searchBtn = By.CssSelector("input[name='btnK']");
            var waitDriver = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = searchInput;
            waitDriver.Until(driver => driver.FindElement(element).Displayed && driver.FindElement(element).Enabled);

            Driver.FindElement(searchInput).SendKeys(text);
            element = searchBtn;
            waitDriver.Until(driver => driver.FindElement(element).Displayed && driver.FindElement(element).Enabled);
            Driver.FindElement(searchBtn).Click();
            return Driver.FindElements(By.XPath("//h3"));
        }


        // Smell 13: Duplicated code (DRY). How to improve

        public IWebDriver WaitUntilElementAppear(By by, TimeSpan timeout)
        {
            var waitDriver = new WebDriverWait(Driver, timeout);
            waitDriver.Until(driver => driver.FindElement(by).Displayed && driver.FindElement(by).Enabled);

            return Driver;
        }

        private readonly By searchInput = By.CssSelector("input[name='q']");
        private readonly By searchBtn = By.CssSelector("input[name='btnK']");

        public void FindInGoogle2(string text)
        {
            WaitUntilElementAppear(searchInput, TimeSpan.FromSeconds(10));
            Driver.FindElement(searchInput).SendKeys(text);

            WaitUntilElementAppear(searchBtn, TimeSpan.FromSeconds(10));
            Driver.FindElement(searchBtn).Click();
        }

        public string GetSearchResultHeader(string text)
        {
            FindInGoogle(text);
            return Driver.FindElement(By.CssSelector("h3")).Text;
        }

        public IEnumerable<IWebElement> GetSearchResultHeadersFix(string text)
        {
            FindInGoogle(text);
            return Driver.FindElements(By.XPath("//h3"));
        }


        // Smell 14: Access file without verification if it exists

        protected long GetFileSize(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            long fileSize = fileInfo.Length;
            return fileSize;
        }

        // Smell 14: Access file without verification if it exists. How to improve
        // in test automation in most cases this is not needed, as any exception fails the test,
        // but still this is code smell

        protected long GetFileSizeFix(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("GetFileSize - file not found", fileName);
            }

            var fileInfo = new FileInfo(fileName);
            long fileSize = fileInfo.Length;
            return fileSize;
        }



        private void When(string v)
        {
            throw new NotImplementedException();
        }
    }

    internal class Favorite
    {
        internal static bool Available(string text)
        {
            throw new NotImplementedException();
        }
    }

}
