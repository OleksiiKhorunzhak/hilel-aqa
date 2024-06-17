namespace NUnitTests.Lessons
{
    public class Lesson5Loops
    {
        [Test]
        public void TestRandomNumbersArray()
        {
            int[] numbers = [42, 23, 4, 16, 29, 7, 95, 85, 12, 38, 76, 54, 9, 21, 11];
            int counter = 0;

            while (counter < numbers.Length)
            {
                Assert.That(numbers[counter], Is.InRange(1, 100));
                counter++;
            }
        }

        //TODO: Create a test to verify sequence using foreach
        [Test]
        public void TestSequenceNumbersArray()
        {
            int[] sequenceNumbers = [3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45];
            int expectedMultiple = 3;

            foreach (var number in sequenceNumbers)
            {
                Assert.That(number % expectedMultiple, Is.EqualTo(0), "Number " + number + " is not a multiple of " + expectedMultiple);
                //expectedMultiple += 3;
            }
        }

        //TODO: Create a test to verify fibonachi sequence
        [Test]
        public void TestFibonacciSequence()
        {
            int[] fibonacci = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181];

            Assert.Multiple(() =>
            {
                // Assert the first two values separately as they are seed values.
                Assert.That(fibonacci[0], Is.EqualTo(0), "First element should be 0.");
                Assert.That(fibonacci[1], Is.EqualTo(1), "Second element should be 1.");
            });

            // Start loop from index 2 as first two values do not follow the sum rule
            for (int index = 2; index < fibonacci.Length; index++)
            {
                Assert.That(fibonacci[index], Is.EqualTo(fibonacci[index - 1] + fibonacci[index - 2]),
                            $"Element at index {index} should be the sum of elements at indexes {index - 1} ({fibonacci[index - 1]}) and {index - 2} ({fibonacci[index - 2]}), but got {fibonacci[index]}.");
            }
        }

        //TODO: Test list range, add more item to list
        [Test]
        public void TestRandomNumbersList()
        {
            List<int> numbers = [42, 23, 4, 16, 29, 7, 95, 85, 12, 38, 76, 54, 9, 21, 11];
            int counter = 0;

            while (counter < numbers.Count)
            {
                Assert.That(numbers[counter], Is.InRange(1, 100));
                counter++; // Increment the counter to avoid infinite loop
            }
        }

        //TODO: Test sequence is multiplied by 3, add more nimbers to list
        [Test]
        public void TestSequenceNumbersList()
        {
            List<int> sequenceNumbers = [3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45];
            int expectedMultiple = 3;

            foreach (int number in sequenceNumbers)
            {
                Assert.That(number % expectedMultiple, Is.EqualTo(0), "Number " + number + " is not a multiple of " + expectedMultiple);
                expectedMultiple += 3;
            }
        }

        [Test]
        public void TestFibonacciSequenceList()
        {
            List<int> fibonacci = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181];

            // Assert the first two values separately as they are seed values.
            Assert.That(fibonacci[0], Is.EqualTo(0), "First element should be 0.");
            Assert.That(fibonacci[1], Is.EqualTo(1), "Second element should be 1.");

            // Start loop from index 2 as first two values do not follow the sum rule
            for (int i = 2; i < fibonacci.Count; i++)
            {
                Assert.That(fibonacci[i], Is.EqualTo(fibonacci[i - 1] + fibonacci[i - 2]),
                            $"Element at index {i} should be the sum of elements at indexes {i - 1} ({fibonacci[i - 1]}) and {i - 2} ({fibonacci[i - 2]}), but got {fibonacci[i]}.");
            }
        }

        private List<string> Friuts = new List<string>
        {
            "Apple", "Ananas", "Banana", "Cherry", "Date", "Eggplant", "Fig", "Grape",
            "Honeydew", "Ivy", "Jackfruit", "Kiwi", "Lemon", "Mango",
            "Nectarine", "Orange", "Peach", "Quince", "Raspberry", "Strawberry",
            "Tomato", "Ugli fruit", "Vanilla", "Watermelon", "Xigua", "Yam", "Zucchini"
        };

        private List<string> SelectItemsByFirstLetter(char letter)
        {
            switch (letter)
            {
                case 'A': return Friuts.Where(i => i.StartsWith("A")).ToList();
                case 'B': return Friuts.Where(i => i.StartsWith("B")).ToList();
                case 'C': return Friuts.Where(i => i.StartsWith("C")).ToList();
                case 'D': return Friuts.Where(i => i.StartsWith("D")).ToList();
                // Continue for the rest of the alphabet...
                case 'X': return Friuts.Where(i => i.StartsWith("X")).ToList();
                case 'Y': return Friuts.Where(i => i.StartsWith("Y")).ToList();
                case 'Z': return Friuts.Where(i => i.StartsWith("Z")).ToList();
                default: return new List<string>(); // No items for letters not in the list
                    //TODO handle continue
            }
        }

        private List<string> SelectItemsByFirstLetterCase(char letter)
        {
            return letter switch
            {
                'A' => Friuts.Where(i => i.StartsWith("A")).ToList(),
                'B' => Friuts.Where(i => i.StartsWith("B")).ToList(),
                'C' => Friuts.Where(i => i.StartsWith("C")).ToList(),
                'D' => Friuts.Where(i => i.StartsWith("D")).ToList(),
                // Continue for the rest of the alphabet...
                'X' => Friuts.Where(i => i.StartsWith("X")).ToList(),
                'Y' => Friuts.Where(i => i.StartsWith("Y")).ToList(),
                'Z' => Friuts.Where(i => i.StartsWith("Z")).ToList(),
                _ => new List<string>(),// No items for letters not in the list
            };
        }

        [Test]
        public void TestCaseSelectionList()
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            foreach (char letter in alphabet)
            {
                List<string> selectedItems = SelectItemsByFirstLetter(letter);
                Assert.That(selectedItems, Is.Not.Empty, $"No items start with the letter {letter}.");
                foreach (var item in selectedItems)
                {
                    Assert.That(item.StartsWith(letter.ToString()), Is.True, $"Item {item} does not start with {letter}.");
                }
            }
        }

        [Test]
        public void RemoveitemTest()
        {
            List<string> list = new List<string>
            {
                 "apple", "banana", "cherry", "date"
             };

            //list.RemoveAll(item => item == "banana");
            
            list.Remove("banana");
            Assert.That(list.Count, Is.EqualTo(3), "The list count isn`t correct after removing an item.");
            Assert.That(list, Does.Not.Contain("banana"), "The list still contains item 'banana'. ");

        }


    }

   // public class ListTests 
    //{
    //    [Test]
    //    public void RemoveitemTest()
    //    {
    //        List<string> list = new List<string>
    //    {
    //             "apple", "banana", "cherry", "date"
    //    };

    //        //list.RemoveAll(item => item == "banana");
    //        list.Remove("banana");
    //        Assert.That(list.Count, Is.EqualTo(3), "The list count isn`t correct after removing an item.");
    //        Assert.That(list, Does.Not.Contain("banana"), "The list still contains item 'banana'. ");

    //    }


    //}








}



