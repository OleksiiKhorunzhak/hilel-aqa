using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ = AtataUI_SolarPanelShop.PageObjects.SolarPanelPage;

namespace AtataUI_SolarPanelShop.PageObjects
{
    [Url("/shop/solar-panels")]
    public sealed class SolarPanelPage : SolarTechnologyPage<_>
    {
        [FindByClass("filter-button")]
        public Link<_> FilterButton { get; private set; }

        [FindByXPath("//label[contains(., 'Jinko Solar')]//input")]
        public CheckBox<_> JinkoSolarCheckbox { get; private set; }

        [FindByXPath("//div[contains(@class, 'prod-holder')]//span[contains(@class, 'list-product-title') and contains(text(), 'Jinko Solar')]")]
        public ControlList<ProductItem<_>, _> JinkoSolarProducts { get; private set; }

        public class ProductItem<TOwner> : Control<TOwner>
                    where TOwner : PageObject<TOwner>
        {

            [FindByXPath(".//span[contains(@class,'list-product-title')]")]
            public Text<_> Title { get; private set; }
        }

    }

}
