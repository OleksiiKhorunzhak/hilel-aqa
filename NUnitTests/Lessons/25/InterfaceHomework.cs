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

        public bool IsIOpenedOnWindows()
        {
            throw new NotImplementedException();
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
