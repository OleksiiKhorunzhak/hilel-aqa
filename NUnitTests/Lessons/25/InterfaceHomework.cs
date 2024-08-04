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

        public bool IsIOpenedOnWindows()
        {
            throw new NotImplementedException();
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

        public bool IsIOpenedOnWindows()
        {
            try
            {
                // run some system call
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool IsIOpenedOnWindows()
        {
            try
            {
                // run some system call
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Close()
        {
            Console.WriteLine($"Closing {DriverName}");
        }


    }

}
