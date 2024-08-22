﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AtataUI_SolarPanelShop.PageObjects.SolarPanelPage;
using _ = AtataUI_SolarPanelShop.PageObjects.SolarBasketPage;

namespace AtataUI_SolarPanelShop.PageObjects
{
    public sealed class SolarBasketPage: SolarTechnologyPage<_>
    {
        //[FindByXPath("//span[contains(text(), 'Jinko Solar 545 Вт')]")]
        //public Control<_> JinkoSolar545Product { get; private set; }

        [FindByXPath("//a[.//span[contains(text(), 'Jinko Solar 545 Вт')]]")]
        public Link<_> JinkoSolar545Product { get; private set; }

        [FindByXPath("//*[@id='cart-modal']//a[@href='/cart']")]
        //[FindByCss(".btn btn-success")]
        public Link<_> MakeOrderBtn { get; private set; }

        [FindByXPath("//span[contains(@class, 'remove-from-cart')]")]
        //[FindByClass("material-icons")]
        public Clickable<_> RemoveItemIcon { get; private set; }

    }
}
