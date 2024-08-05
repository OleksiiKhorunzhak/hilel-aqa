namespace NUnitTests.Lessons._25
{

    public interface IMyWebDriver
    {
        public static readonly string DriverName;
        public void Open(string url);
        public void Close();
	}

    public interface IMyWindowsWebDriver
    {
        public void FindElement(string locator);
        public bool IsIOpenedOnWindows();
	}

    public class CromeDriver : IMyWebDriver, IMyWindowsWebDriver
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

    public class SafariDriver : IMyWebDriver, IMyWindowsWebDriver
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

    public class FirefoxDriver : IMyWebDriver, IMyWindowsWebDriver
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
