namespace NUnitTests.Lessons
{
    internal class Lesson5Loops
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

            foreach (int number in sequenceNumbers)
            {
                Assert.That(number % expectedMultiple, Is.EqualTo(0),
                    "Number " + number + " is not a multiple of " + expectedMultiple);
                expectedMultiple += 3;
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
            for (int i = 2; i < fibonacci.Length; i++)
            {
                Assert.That(fibonacci[i], Is.EqualTo(fibonacci[i - 1] + fibonacci[i - 2]),
                    $"Element at index {i} should be the sum of elements at indexes {i - 1} ({fibonacci[i - 1]}) and {i - 2} ({fibonacci[i - 2]}), but got {fibonacci[i]}.");
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
                Assert.That(number % expectedMultiple, Is.EqualTo(0),
                    "Number " + number + " is not a multiple of " + expectedMultiple);
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

        private List<string> fruits = new List<string>
        {
            "Apple", "Banana", "Cherry", "Date", "Eggplant", "Fig", "Grape",
            "Honeydew", "Ivy", "Jackfruit", "Kiwi", "Lemon", "Mango",
            "Nectarine", "Orange", "Peach", "Quince", "Raspberry", "Strawberry",
            "Tomato", "Ugli fruit", "Vanilla", "Watermelon", "Xigua", "Yam", "Zucchini"
        };

        private List<string> SelectItemsByFirstLetter(char letter)
        {
            switch (letter)
            {
                case 'A': return fruits.Where(i => i.StartsWith('A')).ToList();
                case 'B': return fruits.Where(i => i.StartsWith('B')).ToList();
                case 'C': return fruits.Where(i => i.StartsWith('C')).ToList();
                case 'D': return fruits.Where(i => i.StartsWith('D')).ToList();
                // Continue for the rest of the alphabet...
                case 'X': return fruits.Where(i => i.StartsWith('X')).ToList();
                case 'Y': return fruits.Where(i => i.StartsWith('Y')).ToList();
                case 'Z': return fruits.Where(i => i.StartsWith('Z')).ToList();
                default: return new List<string>(); // No fruits for letters not in the list
            }
        }


        private List<string> SelectItemsByFirstLetterCase(char letter)
        {
            return letter switch
            {
                'A' => fruits.Where(i => i.StartsWith('A')).ToList(),
                'B' => fruits.Where(i => i.StartsWith('B')).ToList(),
                'C' => fruits.Where(i => i.StartsWith('C')).ToList(),
                'D' => fruits.Where(i => i.StartsWith('D')).ToList(),
                // Continue for the rest of the alphabet...
                'X' => fruits.Where(i => i.StartsWith('X')).ToList(),
                'Y' => fruits.Where(i => i.StartsWith('Y')).ToList(),
                'Z' => fruits.Where(i => i.StartsWith('Z')).ToList(),
                _ => new List<string>(), // No fruits for letters not in the list
            };
        }

        [Test]
        public void TestCaseSelectionList()
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            foreach (char letter in alphabet)
            {
                List<string> selectedItems = SelectItemsByFirstLetter(letter);
                Assert.That(selectedItems, Is.Not.Empty, $"No fruits start with the letter {letter}.");
                foreach (var item in selectedItems)
                {
                    Assert.That(item.StartsWith(letter.ToString()), Is.True,
                        $"Item {item} does not start with {letter}.");
                }
            }
        }
    }
}