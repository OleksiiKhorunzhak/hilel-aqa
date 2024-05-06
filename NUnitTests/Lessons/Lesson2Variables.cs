namespace NUnitTests.Lessons
{
    // Lesson Suite Variables
    internal class Lesson2Variables
    {
        //TODO: Scenario - verify maxIntValue = 4294967295
        public int maxIntValue = (int)(Math.Pow(2, 32 -1) - 1);
        //TODO: Scenario - verify minIntValue = -2147483648
        public int minIntValue = (int)(0 - Math.Pow(2, 32 - 1));

        //TODO: Scenario - verify char a return 'a' after UpdateChars method
        public char CharA;
        //TODO: Scenario - verify CharB return 'b' before and after UpdateChars method
        public char CharB = 'b';
        //TODO: Scenario - verify CharC return 'c' after UpdateChars method
        public char CharC;
        //TODO: Scenario - verify CharJ return 'j' after UpdateChars method
        public char CharJ;
        //TODO: Scenario - verify cutestAnimal return null before and 'Cat' after UpdateStrings
        public string? CutestAnimal;
        //TODO: Scenario - verify cutestAnimal return Dog before and 'Dog' after UpdateStrings
        public string BestFriendAnimal = "Dog";
        //TODO: Scenario - verify coolestAnimal return null before and 'Horse' after UpdateStrings with parameter 'Horse'
        public string? CoolestAnimal;

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
    }
}
