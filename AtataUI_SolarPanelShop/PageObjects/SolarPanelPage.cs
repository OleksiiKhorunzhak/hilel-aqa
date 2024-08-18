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

        public ControlList<ProductItem, _> JinkoSolarProducts { get; private set; }

        [ControlDefinition("div", ContainingClass = "prod-holder")]
        public class ProductItem : Control<_>
        {

            [FindByXPath("//span[contains(@class, 'list-product-title')]")]
            public Text<_> Title { get; private set; }
            
            [FindByCss(".add-product-to-cart")]
            public Link<_> AddToCart { get; private set; }
        }

    }

}
