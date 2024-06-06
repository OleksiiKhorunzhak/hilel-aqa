namespace NUnitTests.Lessons
{
    // Lesson Suite Variables
    internal class Lesson2Variables
    {
        #region[TestSetup]
        //TODO: Scenario - verify maxIntValue = 2147483647
        public int maxIntValue = (int)(Math.Pow(2, 32 -1) - 1);


       
        [Test] 
        public void VerifyMaxInt()
        {
            Assert.That(maxIntValue, Is.EqualTo(2147483647), "maxIntValue is not equal to 2147483647");
        }
        //TODO: Scenario - verify maxIntValue2 = 4294967295
        public uint maxIntValue2 = 4294967295;

        [Test]
        public void VerifyMaxInt2()
        {
            Assert.That(maxIntValue2, Is.EqualTo(4294967295), "maxIntValue is not equal to 4294967295");
        }
        //TODO: Scenario - verify minIntValue = -2147483648
        public int minIntValue = (int)(0 - Math.Pow(2, 32 - 1));

        [Test]
        public void VerifyminIntValue()
        {
            Assert.That(minIntValue, Is.EqualTo(-2147483648), "maxIntValue is not equal to -2147483648");
        }

        //TODO: Scenario - verify char a return 'a' after UpdateChars method
        public char CharA;

        [Test]
        public void VerifyCharA()
        {
            var x = 'x';
            UpdateChars(x);
            Assert.That(CharA, Is.EqualTo('a'), "CharA is not equal to a");
        }

        //TODO: Scenario - verify CharB return 'b' before and after UpdateChars method
        public char CharB = 'b';

        [Test]
        public void VerifyCharB()
        {
            Assert.That(CharB, Is.EqualTo('b'), "CharB is not equal to b");
            var k = 'x';
            UpdateChars(k);
            Assert.That(CharB, Is.EqualTo('b'), "CharB is not equal to b");
        }

        //TODO: Scenario - verify CharC return 'c' after UpdateChars method
        public char CharC;

        [Test]
        public void VerifyCharC()
        {
            var k = 'c';
            UpdateChars(k);
            Assert.That(CharC, Is.EqualTo('c'), "CharC is not equal to c");
        }
        //TODO: Scenario - verify CharJ return 'j' after UpdateChars method
        public char CharJ;

        [Test]
        public void VerifyCharJ()
        {
            var k = 'c';
            UpdateChars(k);
            Assert.That(CharJ, Is.EqualTo('j'), "CharC is not equal to j");
        }
        //TODO: Scenario - verify cutestAnimal return null before and 'Cat' after UpdateStrings
        public string? CutestAnimal;

        [Test]
        public void VerifyStringCat()
        {
            Assert.That(CoolestAnimal, Is.EqualTo(null), "CoolestAnimal is not null");
            UpdateStrings();
            Assert.That(CoolestAnimal, Is.EqualTo("Cat"), "CoolestAnimal is not equal Cat");
        }
        //TODO: Scenario - verify cutestAnimal return Dog before and 'Dog' after UpdateStrings
        public string BestFriendAnimal = "Dog";

        [Test]
        public void VerifyStringDog()
        {
            Assert.That(BestFriendAnimal, Is.EqualTo("Dog"), "CoolestAnimal is not dog");
            
            UpdateStrings();
            Assert.That(BestFriendAnimal, Is.EqualTo("Dog"), "CoolestAnimal is not dog");
        }
        //TODO: Scenario - verify coolestAnimal return null before and 'Horse' after UpdateStrings with parameter 'Horse'
        public string? CoolestAnimal;
        [Test]
        public void VerifyStringHorse()
        {
            Assert.That(CoolestAnimal, Is.EqualTo(null), "CoolestAnimal is not null");
            string animal = "Horse";
            UpdateStrings(animal);
            Assert.That(CoolestAnimal, Is.EqualTo(animal), "CoolestAnimal is not horse");
        }
        public void UpdateChars(char charC)
        {
            CharA = 'a';
            CharJ = '\u006A';
            CharC = charC;
        }

        public void UpdateStrings(string setAnimal = "Cat")
        {
            CutestAnimal = setAnimal;
            BestFriendAnimal = "Dog";
            CoolestAnimal = setAnimal;
        }
        #endregion
    }
}
