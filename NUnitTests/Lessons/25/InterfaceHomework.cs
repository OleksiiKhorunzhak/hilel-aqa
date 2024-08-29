namespace NUnitTests.Lessons._25
{

    public interface IMyWebDriver
    {
        // TODO: add methods here
    }

    public interface IMyWindowsWebDriver
    {
        // TODO: add methods here
    }

    public class CromeDriver // TODO: add interfaces here
    {
        public static readonly string DriverName = "Chrome";
        public void Open(string url)
        {
            Console.WriteLine($"Opening {DriverName}");
        }

        public void FindElement(string locator)
        {
            Console.WriteLine($"Find {locator}");
        }

        public void Close()
        {
            Console.WriteLine($"Closing {DriverName}");
        }

        public string GetWindowsVersion()
        {
            return "Windows 10";
        }
    }

    public class SafariDriver // TODO: add interfaces here
    {
        public static readonly string DriverName = "Safari";
        public void Open(string url)
        {
            Console.WriteLine($"Opening {DriverName}");
        }

        public void Close()
        {
            Console.WriteLine($"Closing {DriverName}");
        }

        public void FindElement(string locator)
        {
            Console.WriteLine($"Find {locator}");
        }

    }

    public class FirefoxDriver // TODO: add interfaces here
    {
        public static readonly string DriverName = "Firefox";

        public void FindElement(string locator)
        {
            Console.WriteLine($"Find {locator}");
        }

        public void Open(string url)
        {
            Console.WriteLine($"Opening {DriverName}");
        }

        public string GetWindowsVersion()
        {
            return "Windows 11";
        }

        public void Close()
        {
            Console.WriteLine($"Closing {DriverName}");
        }
    }
}
