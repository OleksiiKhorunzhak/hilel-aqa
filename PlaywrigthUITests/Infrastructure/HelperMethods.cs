using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Infrastructure
{
    internal class HelperMethods
    {
        internal static string GetPathToProjectFolder()
        {
            string pathFile = Directory.GetCurrentDirectory();
            int index = pathFile.IndexOf("bin");
            if (index >= 0)
            {
                pathFile = pathFile.Remove(index);
            }
            return  pathFile.Replace("\\", "/");
        }

        internal static string GetArtifactsDirectoryPath()
        {
            AtataContext context = AtataContext.Current;
            if (context == null)
            {
                throw new InvalidOperationException("Atata context is not initialized");
            }
            string artifactsDirectoryPath = context.Artifacts.FullName;

            return artifactsDirectoryPath.ToString();
        }

    }
}
