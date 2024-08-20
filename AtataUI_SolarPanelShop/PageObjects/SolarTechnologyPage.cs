using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUI_SolarPanelShop.PageObjects
{
    [Url("https://solartechnology.com.ua/")]
   
    public abstract class SolarTechnologyPage<TOwner>: Page<TOwner>
        where TOwner : SolarTechnologyPage<TOwner>
    {

    }
}
