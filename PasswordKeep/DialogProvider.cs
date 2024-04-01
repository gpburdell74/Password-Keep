using PasswordKeep.Ops;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides static methods and functions for displauing common dialogs.
	/// </summary>
	public static class DialogProvider
	{
		/// <summary>
		/// Creates the open file dialog instance to prompt the user to open a file.
		/// </summary>
		/// <returns>
		/// An <see cref="OpenFileDialog"/> instance.
		/// </returns>
		public static OpenFileDialog CreateOpenFileDialog(string? fileName = null)
		{
			// Select the file to open.
			OpenFileDialog dialog = new OpenFileDialog
			{
				AddExtension = true,
				AddToRecent = true,
				AutoUpgradeEnabled = true,
				CheckFileExists = true,
				CheckPathExists = true,
				DefaultExt = FileConstants.ExtensionSecureFile,
				Filter = FileConstants.FilterSecureAndClearFile,
				SupportMultiDottedExtensions = true,
				Title = Properties.Resources.DialogTitleOpen
			};
			if (!string.IsNullOrEmpty(fileName))
			{
				dialog.FileName = fileName;
			}
			return dialog;
		}
		/// <summary>
		/// Creates the save file dialog instance to prompt the user to create or save a file.
		/// </summary>
		/// <returns>
		/// A <see cref="SaveFileDialog"/> instance.
		/// </returns>
		public static SaveFileDialog CreateSaveFileDialog(string? originalFileName = null)
		{
			SaveFileDialog dialog = new SaveFileDialog
			{
				AddExtension = true,
				AddToRecent = true,
				AutoUpgradeEnabled = true,
				CheckWriteAccess = true,
				OverwritePrompt = true,
				DefaultExt = FileConstants.ExtensionSecureFile,
				Filter = FileConstants.FilterSecureFile,
				SupportMultiDottedExtensions = true,
				Title = Properties.Resources.DialogTitleCreateNew
			};

			if (!string.IsNullOrEmpty(originalFileName))
			{
				dialog.FileName = originalFileName;
			}
			return dialog;
		}
	}
}
