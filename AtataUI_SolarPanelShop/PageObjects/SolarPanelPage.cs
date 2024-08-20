using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AtataUI_SolarPanelShop.PageObjects.SolarPanelPage;
using _ = AtataUI_SolarPanelShop.PageObjects.SolarPanelPage;

namespace AtataUI_SolarPanelShop.PageObjects
{
    [Url("/shop/solar-panels")]
    public sealed class SolarPanelPage : SolarTechnologyPage<_>
    {

        [FindById("p_prldr")]
        public Clickable<_> PageLoaded { get; private set; }
        
        [FindByClass("cart-icon")]
        public ListItem<_> CartIcon { get; private set; }
                
        [FindByClass("cart-icon labeled")]
        public ListItem<_> CartIconWithProducts { get; private set; }

        [FindByClass("filter-button")]
        public Link<_> FilterButton { get; private set; }

        [FindByXPath("//label[contains(., 'Jinko Solar')]//input")]
        public CheckBox<_> JinkoSolarCheckbox { get; private set; }

        //[FindByXPath("//div[contains(@class, 'prod-holder')]//span[contains(@class, 'list-product-title') and contains(text(), 'Jinko Solar')]")]
        public ControlList<ProductItem, _> JinkoSolarProducts { get; private set; }

        [ControlDefinition("div", ContainingClass = "prod-holder")]
        public class ProductItem : Control<_>
        {
            [FindByXPath("//span[contains(@class,'list-product-title')]")]
            public Text<_> Title { get; private set; }

            //[FindByXPath("//button[contains(@class, 'add-product-to-cart')]")]
            //[FindByCss(".add-product-to-cart")]
            [FindByClass("add-product-to-cart")]
            public Link<_> AddToCartButton { get; private set; }

        }

    }

}
