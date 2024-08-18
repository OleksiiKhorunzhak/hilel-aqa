﻿using System;
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
            //page.WaitSeconds(10).Until(() => page.JinkoSolarProducts.Count > 0);
                                  foreach (var product in page.JinkoSolarProducts)
                                  {
                                        product.Title.Should.BePresent();
                                        product.Title.Should.Contain("Jinko Solar");
                                  }
                       

        }

    }
    

}
