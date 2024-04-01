using System.Text;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides static methods / functions for interacting with the operating system.
	/// </summary>
	public static class OSUtilities
	{
		#region Private Constants		
		/// <summary>
		/// The explorer executable name.
		/// </summary>
		private const string ExplorerExe = "\\explorer.exe";
		#endregion

		#region Public Methods / Functions
		/// <summary>
		/// Attempts to start the default web browser session and open the specified URL value.
		/// </summary>
		/// <param name="url">
		/// A string containing the URL value to browse to.
		/// </param>
		public static void StartBrowser(string url)
		{
			string? callToInvoke = RenderBrowserStartCommand(url);
			if (callToInvoke != null)
			{
				try

				{
					System.Diagnostics.Process.Start(callToInvoke);
				}
				catch (Exception ex)
				{

				}
			}
		}
		#endregion

		#region Private Methods / Functions		
		/// <summary>
		/// Renders the command line needed to start the browser to browse to the specified URL.
		/// </summary>
		/// <param name="url">
		/// A string containing the URL value to browse to.
		/// </param>
		/// <returns>
		/// A string containing the command, or <b>null</b> if the operation is not valid.
		/// </returns>
		private static string? RenderBrowserStartCommand(string url)
		{
			string? callPath = null;

			string? windowsPath = GetWindowsPath();
			if (!string.IsNullOrEmpty(windowsPath) && !string.IsNullOrEmpty(url))
			{
				StringBuilder builder = new StringBuilder();

				//  <drive>:\<path>
				builder.Append(windowsPath);

				// \explorer.exe 
				builder.Append(ExplorerExe);

				// "<some url here>"
				builder.Append(" \"");
				builder.Append(url);
				builder.Append("\"");

				// Should look similar to:
				// C:\Windows\explorer.exe "http://www.microsoft.com"
				callPath = builder.ToString();
				builder.Clear();
			}

			return callPath;

		}
		/// <summary>
		/// Gets the Windows operating system path.
		/// </summary>
		/// <returns>
		/// A stirng containing the path, if successful; otherwise, returns <b>null</b>.
		/// </returns>
		private static string? GetWindowsPath()
		{
			string? path = null;

			try
			{
				path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
			}
			catch(Exception ex)
			{
				path = null;
			}

			return path;
		}
		#endregion
	}
}
