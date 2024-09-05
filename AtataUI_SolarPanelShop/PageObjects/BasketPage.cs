using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AtataUI_SolarPanelShop.PageObjects.CatalogPage;
using _ = AtataUI_SolarPanelShop.PageObjects.BasketPage;

namespace AtataUI_SolarPanelShop.PageObjects
{
    public sealed class BasketPage: SolarTechnologyPage<_>
    {

        [FindByXPath("//*[@id='cart-modal']//a[@href='/cart']")]
        //[FindByCss(".btn btn-success")]
        public Link<_> MakeOrderBtn { get; private set; }

        [FindByXPath("//span[contains(@class, 'remove-from-cart')]")]
        //[FindByClass("material-icons")]
        public Clickable<_> RemoveItemIcon { get; private set; }

    }
}
