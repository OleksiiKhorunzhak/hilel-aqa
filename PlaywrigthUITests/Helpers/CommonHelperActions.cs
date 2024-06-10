using System;

namespace PlaywrigthUITests.Helpers
{
	public static class CommonHelperActions
	{
		public static string GetPathToProjectFolder()
		{
			string pathFile = Directory.GetCurrentDirectory();
			int index = pathFile.IndexOf("bin");
			return pathFile = pathFile.Remove(index);
		}
	}
}
