using _ = AtataUI_SolarPanelShop.PageObjects.BasketlPage;

namespace AtataUI_SolarPanelShop.PageObjects
{
    public sealed class BasketlPage : SolarTechnologyPage<_>
    {
        [FindByXPath("//*[@id='cart-modal']//a[@href='/cart']")]
        public Link<_> MakeOrderBtn { get; private set; }
    }

}
