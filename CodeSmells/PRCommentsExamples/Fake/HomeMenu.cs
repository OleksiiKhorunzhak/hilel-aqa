using Microsoft.Playwright;

namespace CodeSmells.PRCommentsExamples
{
    internal class HomeMenu
    {
        private IPage page;

        public HomeMenu(IPage page)
        {
            this.page = page;
        }

        internal async Task GoToShoppingCart()
        {
            throw new NotImplementedException();
        }
    }
}