namespace PlaywrigthUITests.Infrastructure
{
    internal class HelperMethods
    {
        internal static string GetProjectFilePath()
        {
            string pathFile = Directory.GetCurrentDirectory();
            int index = pathFile.IndexOf("bin");
            if (index >= 0)
            {
                pathFile = pathFile.Remove(index);
            }
            return pathFile.Replace("\\", "/");
        }
    }
}
