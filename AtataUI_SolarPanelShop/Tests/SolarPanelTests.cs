using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atata;
using AtataUI_SolarPanelShop.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AtataUI_SolarPanelShop.Tests
{
    [Description(" Verify certain basіс functionality works correctly")]
    public sealed class WEBShopTests : UITestFixture
    {
        [Test, Description("Verify FilterButton is enabled")]
        public void VerifyFilterButtonIsEnabled()
        {
            Go.To<CatalogPage>().
                FilterButton.Should.BeEnabled().
                FilterButton.Click();

        }

        [Test, Description("Verify checkbox-brand filter with lable'Jinko Solar' is visible and checked")]

        public void VerifyJinkoSolarCheckboxFilterVisibleAndChecked()
        {
            Go.To<CatalogPage>().
                FilterButton.Click().
                JinkoSolarCheckbox.ScrollTo().
                        JinkoSolarCheckbox.Should.BePresent().
                        JinkoSolarCheckbox.Should.BeUnchecked().
                        JinkoSolarCheckbox.Script.Click().
                                  JinkoSolarCheckbox.Should.BeChecked();

        }

        [Test, Description("Verify checkbox-brand filter with lable'Jinko Solar' is filtered")]

        public void VerifyFilterByJinkoSolarBrandFiltered()
        {
            var page = Go.To<CatalogPage>();
            var countBefore = page.JinkoSolarProducts.Count;
            page.JinkoSolarCheckbox.Script.Click().
            JinkoSolarCheckbox.Should.BeChecked().
            JinkoSolarProducts.Count.WaitTo.BeLess(countBefore);
            
            foreach (var product in page.JinkoSolarProducts)
            {
                Assert.That(page.JinkoSolarProducts.Count.Value, Is.GreaterThan(0), "No products found after filtering by 'Jinko Solar'.");
                product.Title.Should.BePresent();
                product.Title.Should.Contain("Jinko Solar");
                //Assert.That(product.Title.Value, Does.Contain("Jinko Solar"), "The product title  does not contain 'Jinko Solar'.");
            }

        }

        //[Test, Description("Verify that product can be added and removed from the Shopping Cart")]
        //public void AddAndRemoveJinkoSolar455ProductFromBasket()
        //{
        //    var page = Go.To<SolarPanelPage>();
        //    var basketPage = page.JinkoSolarProducts[0].AddToCartButton.ScrollTo().
        //    JinkoSolarProducts[0].AddToCartButton.WaitTo.BeEnabled().
        //    JinkoSolarProducts[0].AddToCartButton.ClickAndGo<SolarBasketPage>();
        //    basketPage.MakeOrderBtn.WaitTo.BeVisible();
        //    basketPage.MakeOrderBtn.Click();
        //    page.PageLoaded.WaitTo.BeVisible();
        //    page.PageLoaded.WaitTo.BeHidden();
        //    basketPage.RemoveItemIcon.WaitTo.BeVisibleInViewport();
        //    basketPage.RemoveItemIcon.WaitTo.BeEnabled();
        //    basketPage.RemoveItemIcon.Click();
        //    page.CartIcon.WaitTo.BeVisible().
        //    CartIconWithProducts.Should.Not.BePresent();

        //}


        [TestCase(0, Description = "Verify that product with index 0 can be added and removed from the Shopping Cart")]
        [TestCase(1, Description = "Verify that product with index 1 can be added and removed from the Shopping Cart")]
        public void AddAndRemoveJinkoSolarProductsFromBasket(int productIndex)
        {
            var page = Go.To<CatalogPage>();
            page.JinkoSolarProducts[productIndex].AddToCartButton.ScrollTo().
                 JinkoSolarProducts[productIndex].AddToCartButton.WaitTo.BeEnabled().
                 JinkoSolarProducts[productIndex].AddToCartButton.ClickAndGo<BasketPage>().
                 MakeOrderBtn.WaitTo.BeVisible().MakeOrderBtn.Click();
            page.PageLoaded.WaitTo.BeVisible().
                 PageLoaded.WaitTo.BeHidden();
            Go.On<BasketPage>().
                 RemoveItemIcon.WaitTo.BeVisibleInViewport().
                 RemoveItemIcon.WaitTo.BeEnabled().
                 RemoveItemIcon.Click();
            page.CartIcon.WaitTo.BeVisible().
                 CartIconWithProducts.Should.Not.BePresent();

        }



        [Test, Description("Verify appropriate Product Details about certain Product when user click on it")]
        public void VerifyProductDetailsJinkoSolar455Product()
        {
            var page = Go.To<CatalogPage>();
                page.JinkoSolarProducts[0].ScrollTo();
            var selectedProductName = page.JinkoSolarProducts[0].Title.Value;
                page.JinkoSolarProducts[0].Click();
                page.ProductTitle.WaitTo.BeVisible().
                ProductTitle.Should.Contain(selectedProductName);
            
            Assert.That(page.ProductPower.Value, Is.EqualTo("455 Вт"), "The power value of the product is not equal '455 Вт'.");

        }

       
    }
}
