using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Infrastructure
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

        internal static string GetArtifactsDirectoryPath()
        {
            // Ensure that Atata context is initialized
            AtataContext context = AtataContext.Current;
            if (context == null)
            {
                throw new InvalidOperationException("Atata context is not initialized.");
            }

            string artifactsDirectoryPath = context.Artifacts.FullName;

            // Get the artifacts directory path
            //var artifactsDirectoryPath = context.Artifacts.Directories;

            // Output or use the artifacts directory path as needed
            return artifactsDirectoryPath.ToString();
        }
    }
}
