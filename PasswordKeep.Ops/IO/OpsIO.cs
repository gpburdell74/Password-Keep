using Adaptive.Intelligence.Shared.IO;

namespace PasswordKeep.Ops
{
	/// <summary>
	/// Provides static methods / functions for performing I/O operations.
	/// </summary>
	public static class OpsIO 
	{
		/// <summary>
		/// Creates a new, unique file name in order to back up the original file.
		/// </summary>
		/// <param name="originalFileName">
		/// A string containing the fully-qualfied path and name of the original file.
		/// </param>
		/// <returns>
		/// A string containing the new file name of the backup file to be created, or <b>null</b> if the operation fails.
		/// </returns>
		public static string? GetBackupFileName(string? originalFileName)
		{
			string? backupFileName = null;	

			if (!string.IsNullOrEmpty(originalFileName) && SafeIO.FileExists(originalFileName))
			{
				string? path = Path.GetDirectoryName(originalFileName);
				string? baseFileName = Path.GetFileNameWithoutExtension(originalFileName);
				string? extension = Path.GetExtension(originalFileName);

				if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(baseFileName) && !string.IsNullOrEmpty(extension) )
				{
					int counter = 0;
					bool exists = true;
					do
					{
						backupFileName = path + "\\" + baseFileName + counter.ToString() + "." + extension + ".bak";
						exists = SafeIO.FileExists(backupFileName);
						counter++;
					} while (counter < 512 && exists);
				}

				return backupFileName;
			}

			return backupFileName;

		}
		/// <summary>
		/// Tries to create a backup of the specified file.
		/// </summary>
		/// <param name="originalFileName">
		/// A string containing the fully-qualfied path and name of the original file.
		/// </param>
		/// <returns>
		/// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public static bool BackupFile(string? originalFileName)
		{
			bool success = false;

			if (!string.IsNullOrEmpty(originalFileName))
			{
				// Generate a new backup file name.
				string? backupFileName = GetBackupFileName(originalFileName);
				if (!string.IsNullOrEmpty(backupFileName))
				{
					// Copy the priginal to the new backup file.
					success = SafeIO.CopyFile(originalFileName, backupFileName);
				}
			}
			return success;
		}
		/// <summary>
		/// Opens the file for reading the content.
		/// </summary>
		/// <param name="fileName">
		/// A string containing the fully-qualfied path and name of the file to be read.
		/// </param>
		/// <returns>
		/// An open <see cref="FileStream"/> to be read from if successful; otherwise, returns <b>null</b>.
		/// </returns>
		public static FileStream? OpenFileForReading(string? fileName)
		{
			FileStream? readStream = null;

			if (!string.IsNullOrEmpty(fileName))
			{
				if (SafeIO.FileExists(fileName))
				{
					try
					{
						readStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
					}
					catch(Exception )
					{
						// TODO: Global Logging.
					}
				}
			}
			return readStream;
		}
		/// <summary>
		/// Opens the file for saving the content.
		/// </summary>
		/// <remarks>
		/// This method attempts to create a backup copy of the specified file if it already exists, then deletes the original,
		/// and re-creates the file for writing.
		/// </remarks>
		/// <param name="originalFileName">
		/// A string containing the fully-qualfied path and name of the original file.
		/// </param>
		/// <returns>
		/// An open <see cref="FileStream"/> to be written to if successful; otherwise, returns <b>null</b>.
		/// </returns>
		public static FileStream? OpenFileForSaving(string? originalFileName)
		{
			FileStream? saveToFileStream = null;

			if (!string.IsNullOrEmpty(originalFileName))
			{
				if (BackupFile(originalFileName))
				{
					if (SafeIO.DeleteFile(originalFileName))
					{
						try
						{
							saveToFileStream = new FileStream(originalFileName, FileMode.CreateNew, FileAccess.Write);
						}
						catch (Exception)
						{
							saveToFileStream = null;
							// TODO: Global logging.
						}
					}
				}
			}

			return saveToFileStream;
		}
	}
}
