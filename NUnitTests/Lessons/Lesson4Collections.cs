namespace NUnitTests.Lessons
{
    internal class Lesson4Collections
    {
        public string[] EuropeanCountriesArray = new string[]
        {
            "Albania", "Andorra", "Armenia", "Austria", "Belgium",
            "Bosnia and Herzegovina", "Bulgaria", "Croatia", "Cyprus", "Czech Republic",
            "Denmark", "Estonia", "Finland", "France", "Georgia", "Germany", "Greece",
            "Hungary", "Iceland", "Ireland", "Italy", "Kosovo", "Latvia", "Liechtenstein",
            "Lithuania", "Luxembourg", "Malta", "Moldova", "Monaco", "Montenegro",
            "Netherlands", "North Macedonia", "Norway", "Poland", "Portugal", "Romania",
            "San Marino", "Serbia", "Slovakia", "Slovenia", "Spain", "Sweden",
            "Switzerland", "Ukraine", "United Kingdom", "Vatican City"
        };

        public int[] CountryPopulations = new int[]
        {
        2877797, 77265, 2963243, 8917205, 11589623,
        3280819, 6951482, 4105267, 1207359, 10708981,
        5822763, 1326535, 5540718, 67320213, 3717000, 83149300, 10423054,
        9660351, 356991, 4937796, 60461826, 1810469, 1886198, 38128,
        2722291, 625978, 441543, 3545883, 39242, 628066,
        17441139, 2083374, 5421241, 37978548, 10196709, 19237691,
        33931, 6908224, 5455000, 2078938, 46754778, 10286162,
        8570146, 41632422, 67886011, 801
        };

        //TODO: test SelectCountriesStartingWith
        public string[] SelectCountriesStartingWith(string[] selectFromArray, char startsFrom)
        {
            // Ensure the character is uppercase for comparison, assuming input might not be consistent
            char upperStartsFrom = char.ToUpper(startsFrom);

            // Filter the array using LINQ where the starting letter matches 'startsFrom' character
            return selectFromArray.Where(country => char.ToUpper(country[0]) == upperStartsFrom).ToArray();
        }

        //TODO: test SortCountries, verify sot corresponds ascend = true descend = false
        public string[] SortCountries(string[] arrayToSort, bool sortAscDesc)
        {
            if (sortAscDesc)
            {
                // Sort the array in ascending order if sortAscDesc is true
                return arrayToSort.OrderBy(country => country).ToArray();
            }
            else
            {
                // Sort the array in descending order if sortAscDesc is false
                return arrayToSort.OrderByDescending(country => country).ToArray();
            }

            //return sortAscDesc
            //? arrayToSort.OrderBy(country => country).ToArray()
            //: arrayToSort.OrderByDescending(country => country).ToArray();
        }

        //TODO: test CombineCountryAndPopulation
        public string[] CombineCountryAndPopulation(string[] countries, int[] populations)
        {
            //TODO: Add countries and populations array size check
            if (true)
            {
                throw new ArgumentException("Countries and populations arrays must be of the same length.");
            }

            string[] combined = new string[countries.Length];
            for (int i = 0; i < countries.Length; i++)
            {
                //TODO: fix type to string for population
                combined[i] = $"Country " + countries[i] + " population is " + populations[i] + " people!";
            }

            return combined;
        }
    }
}
