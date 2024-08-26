
namespace DifferentExamples
{
    internal class AssertExamples
    {
        dynamic Page;
        dynamic MenuPage;
        dynamic SelectYourPizzaPage;
        dynamic OrderPage;

        [Test]
        public async Task GuessWhatDoIDo_1()
        {
            await Page.GoToMascarponePizzaPage();
            await Page.VerifyMascarponePizzaPageIsOk();
            await Page.ClickExpand();
            await Page.VerifyExpandIsVisible();
            await Page.ClickAdd(2);
            await Page.ClickAdd(5);
            await Page.ClickAdd(6);
            await Page.ClickOnConfirm();
            await Page.VerifyIsConfirmed();
            await Page.ClickOnFinish();
            await Page.VerifyOrderPageIsCorrect();
            await Page.VerifyOrderCode(203);
        }

        [Test]
        public async Task GuessWhatDoIDo_2()
        {
            //Arrange 
            await MenuPage.SelectPizza("Mascarpone");
            await SelectYourPizzaPage.ExpandIngredients();

            //Act
            await SelectYourPizzaPage.AddIngredient("cheese");
            await SelectYourPizzaPage.AddIngredient("pepper");
            await SelectYourPizzaPage.AddIngredient("beacon");
            await SelectYourPizzaPage.ConfirmIngredients();
            await OrderPage.ConfirmOrder();
            var ingredientsNumber = await OrderPage.GetIngredientsNumber();
            var orderTotal = await OrderPage.GetTotal();

            //Assert
            Assert.That(ingredientsNumber, Is.EqualTo(3));
            Assert.That(orderTotal, Is.EqualTo(15.87));
        }
    }
}
