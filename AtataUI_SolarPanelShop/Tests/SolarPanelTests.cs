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
    [Description(" Verify that catalog filter works correctly")]
    public sealed class CatalogFilterTests: UITestFixture
    {
        [Test, Description("Verify FilterButton is enabled")]
         public void VerifyFilterButtonIsEnabled() 
         {
            Go.To<SolarPanelPage>().
                FilterButton.Should.BeEnabled().
                FilterButton.Click();

         }

        [Test, Description("Verify checkbox-brand filter with lable'Jinko Solar' is visible and checked")]

        public void VerifyJinkoSolarCheckboxFilterVisibleAndChecked()
        {
            Go.To<SolarPanelPage>().
                FilterButton.Should.BeEnabled().
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
            var page = Go.To<SolarPanelPage>().
                FilterButton.Should.BeEnabled().
                FilterButton.Click().
                JinkoSolarCheckbox.ScrollTo().
                        JinkoSolarCheckbox.Should.BePresent().
                        JinkoSolarCheckbox.Should.BeUnchecked().
                        JinkoSolarCheckbox.Script.Click().
                                  JinkoSolarCheckbox.Should.BeChecked();
                                  foreach (var product in page.JinkoSolarProducts)
                                  {
                                        product.Title.Should.BePresent();
                                        product.Title.Should.Contain("Jinko Solar");
                                  }


        }

        [Test, Description("Verify that product can be added and removed from the Shopping Cart")]
        public void AddAndRemoveJinkoSolarProductFromBusket()
        {
            var page = Go.To<SolarPanelPage>().
                PageLoaded.WaitTo.BeHidden(). 
                FilterButton.Click().
                JinkoSolarCheckbox.ScrollTo();
            var countBefore = page.JinkoSolarProducts.Count;
            page.JinkoSolarCheckbox.Script.Click().
                 JinkoSolarCheckbox.Should.BeChecked().
                 JinkoSolarProducts.Count.WaitTo.BeLess(countBefore);
            var basketPage = page.JinkoSolarProducts[0].AddToCartButton.ScrollTo().
                JinkoSolarProducts[0].AddToCartButton.WaitTo.BeEnabled().
                JinkoSolarProducts[0].AddToCartButton.ClickAndGo<SolarBasketPage>();
            basketPage.MakeOrderBtn.WaitTo.BeVisible();
            basketPage.MakeOrderBtn.Click();
            page.PageLoaded.WaitTo.BeVisible();
            page.PageLoaded.WaitTo.BeHidden();
            basketPage.RemoveItemIcon.WaitTo.BeVisibleInViewport();
            basketPage.RemoveItemIcon.WaitTo.BeEnabled();
            basketPage.RemoveItemIcon.Click();
            page.CartIcon.WaitTo.BeVisible().
                CartIconWithProducts.Should.Not.BePresent();
            //basketPage.EmptyCartMessage.WaitTo.BeVisible();
        }


        [Test, Description("Verify that product can be added and removed from the Shopping Cart")]
        public void AddAndRemoveJinkoSolarProduct545FromBusket()
        {
            var page = Go.To<SolarPanelPage>().
            FilterButton.Click().
                JinkoSolarCheckbox.ScrollTo();
            var countBefore = page.JinkoSolarProducts.Count;
            page.JinkoSolarCheckbox.Script.Click().
                 JinkoSolarCheckbox.Should.BeChecked().
                 JinkoSolarProducts.Count.WaitTo.BeLess(countBefore);
            page.JinkoSolarProducts[1].AddToCartButton.ScrollTo().
                   JinkoSolarProducts[1].AddToCartButton.ClickAndGo<SolarBasketPage>().
                   MakeOrderBtn.WaitTo.BeVisible().MakeOrderBtn.Click().
                   RemoveItemIcon.Click();
                           //EmptyCartMessage.WaitTo.BeVisible();
        }


    }

    





}
