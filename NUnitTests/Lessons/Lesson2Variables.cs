namespace NUnitTests.Lessons
{
    // Lesson Suite Variables
    internal class Lesson2Variables
    {
        #region[TestSetup]
        //TODO: Scenario - verify maxIntValue2 = 2147483647
        public int maxIntValue = (int)(Math.Pow(2, 32 - 1) - 1);

        [Test]
        public void VerifyMaxIntValue()
        {
            Assert.That(maxIntValue, Is.EqualTo(2147483647), "maxIntValue is not equal to 2147483647");
        }
        //[Test]
        //public void TestMaxIntValue()
        //{
        //    Assert.That(maxIntValue, Is.EqualTo(2147483647), "maxIntValue is not equal to 2147483647");
        //}

        //TODO: Scenario - verify maxIntValue2 = 4294967295
        public uint maxIntValue2 = 4294967295;

        [Test]
        public void VerifyMaxUintValue()
        {
            Assert.That(maxIntValue2, Is.EqualTo(4294967295), "maxIntValue2 is not equal to 4294967295");
        }
        //[Test]
        //public void TestMaxUnSignedValue()
        //{
        //    Assert.That(maxIntValue2, Is.EqualTo(4294967295), "maxIntValue2 is not equal to 4294967295");
        //}

        //TODO: Scenario - verify minIntValue = -2147483648
        public int minIntValue = (int)(0 - Math.Pow(2, 32 - 1));

        [Test]
        public void VerifyMinIntValue()
        {
           Assert.That(minIntValue, Is.EqualTo(-2147483648), "minIntValue is not equal to -2147483648"); 
        }

        //[Test]
        //public void TestMinIntValue()
        //{
        //    Assert.That(minIntValue, Is.EqualTo(-2147483648), "minIntValue is not equal to -2147483648");
        //}

        //TODO: Scenario - verify CharA return 'a' after UpdateChars method
        public char CharA;

        [Test]
        public void VerifyCharA_return_a()
        {
            var a = 'a';
            UpdateChars(a);
            Assert.That(CharA, Is.EqualTo(a), "CharA is not equal to 'a'");
        }

        //[Test]
        //public void TestCharA()
        //{
        //    var a = 'a';
        //    UpdateChars(a);
        //    Assert.That(CharA, Is.EqualTo('a'), "CharA is not eual to 'a'");
        //}

        //TODO: Scenario - verify CharB return 'b' before and after UpdateChars method
        public char CharB = 'b';

        [Test]
        public void VerifyCharB_return_b()
        {
            var a = 'a';
            Assert.That(CharB, Is.EqualTo('b'), "Char b is not equal to 'b' before UpdateChars method");
            UpdateChars(a);
            Assert.That(CharB, Is.EqualTo('b'), "Char b is not equal to 'b' after UpdateChars method");
        }
        //[Test]
        //public void TestCharB()
        //{
        //    var a = 'a';
        //    Assert.That(CharB, Is.EqualTo('b'), "CharB is not eual to 'b'");
        //    UpdateChars(a);
        //    Assert.That(CharB, Is.EqualTo('b'), "CharB is not eual to 'b'");
        //}

        //TODO: Scenario - verify CharC return 'c' after UpdateChars method
       
        public char CharC;

        [Test]
        public void VerifyCharC_return_c()
        {
            var a = 'c';
            UpdateChars(a);
            Assert.That(CharC, Is.EqualTo('c'), "CharC is not equal to 'c' after UpdateChars method");
        }

        //[Test]
        //public void TestCharC()
        //{
        //    var a = 'c';
        //    UpdateChars(a);
        //    Assert.That(CharC, Is.EqualTo('c'), "CharC is not eual to 'c'");
        //}

        //TODO: Scenario - verify CharJ return 'j' after UpdateChars method
        
        public char CharJ;

        [Test]
        public void VerifyCharJ_return_j()
        {
            var a = 'O';   
            UpdateChars(a);
            Assert.That(CharJ,Is.EqualTo('j'), "CharJ is not equal to 'j' after UpdateChars method");
        }
        //[Test]
        //public void TestCharJ()
        //{
        //    var a = 'a';
        //    UpdateChars(a);
        //    Assert.That(CharJ, Is.EqualTo('j'), "CharJ is not eual to 'j'");
        //}

        //TODO: Scenario - verify cutestAnimal return null before and 'Cat' after UpdateStrings
        
        public string? CutestAnimal;

        [Test]
        public void Verify_string_CutestAnimal()
        {
            Assert.That(CutestAnimal, Is.EqualTo(null), "string CutestAnimal is not Null");
            UpdateStrings();
            Assert.That(CutestAnimal,Is.EqualTo("Cat"), "string CutestAnimal is not 'Cat'");
        }

        //[Test]
        //public void TestStringA()
        //{
        //    Assert.That(CutestAnimal, Is.EqualTo(null), "String is not eual to 'null'");
        //    UpdateStrings();
        //    Assert.That(CutestAnimal, Is.EqualTo("Cat"), "String is not eual to 'Cat'");
        //}

        //TODO: Scenario - verify BestFriendAnimal return Dog before and 'Dog' after UpdateStrings
        
        public string BestFriendAnimal = "Dog";

        [Test]
        public void Verify_string_BestFriendAnimal()
        {
            Assert.That(BestFriendAnimal, Is.EqualTo("Dog"), "string BestFriendAnimal is not 'Dog' before UpdateStrings");
            UpdateStrings();
            Assert.That(BestFriendAnimal, Is.EqualTo("Dog"), "string BestFriendAnimal is not 'Dog' after UpdateStrings");
        }

        //[Test]
        //public void TestStringB()
        //{
        //    Assert.That(BestFriendAnimal, Is.EqualTo("Dog"), "String is not eual to 'null'");
        //    UpdateStrings();
        //    Assert.That(BestFriendAnimal, Is.EqualTo("Dog"), "String is not eual to 'Cat'");
        //}

            //TODO: Scenario - verify coolestAnimal return null before and 'Horse' after UpdateStrings with parameter 'Horse'

        public string? CoolestAnimal;
        
        [Test]
        public void Verify_string_CoolestAnimal()
        {
            string testAnimal = "Horse";
            
            Assert.That(CoolestAnimal, Is.EqualTo(null), "CoolestAnimal is not Null before UpdateStrings");
            UpdateStrings(testAnimal);
            Assert.That(CoolestAnimal, Is.EqualTo(testAnimal), "CoolestAnimal is not 'Horse' after UpdateStrings");
        }

        //[Test]
        //public void TestStringC()
        //{
        //    string animal = "Horse";
        //    Assert.That(CoolestAnimal, Is.EqualTo(null), "String is not eual to 'Horse'");
        //    UpdateStrings(animal);
        //    Assert.That(CoolestAnimal, Is.EqualTo(animal), "String is not eual to 'Horse'");
        //}

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
