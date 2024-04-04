using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Ops
{
	/// <summary>
	/// Provides static methods / functions for adding versioning to the data files.
	/// </summary>
	public static class AppVersionReaderWriter
	{
		private static readonly byte[] ApplicationHeader = { 42, 19, 74, 11, 13 };
		/// <summary>
		/// Reads the version of the file from the provided stream.
		/// </summary>
		/// <param name="sourceStream">
		/// The source <see cref="Stream"/> to read from.
		/// </param>
		/// <returns>
		/// A byte array containing the version of the application that wrote the file,
		/// or <b>null</b> if the data is not present.
		/// </returns>
		public static byte[]? ReadVersion(Stream sourceStream)
		{
			byte[]? versionData = null;
			byte[] headerData = new byte[5];
			sourceStream.Read(headerData, 0, 5);

			// If the application header is not present, reset the stream to the beginning and
			// assume there is no version data.
			if (ArrayExtensions.Compare(headerData, ApplicationHeader) != 0)
			{
				sourceStream.Seek(0, SeekOrigin.Begin);
			}
			else
			{
				// Read the version data.
				versionData = new byte[] { 0, 0, 0, 0 };
				sourceStream.Read(versionData, 0, 4);
			}
			return versionData;
		}
		/// <summary>
		/// Writes the version data to the output stream.
		/// </summary>
		/// <param name="destinationStream">
		/// The destination <see cref="Stream"/> instance to be written to.
		/// </param>
		public static void WriteVersion(Stream destinationStream)
		{
			// Write the application header so we know the version data is present in this file.
			destinationStream.Write(ApplicationHeader);

			// Currently - Beta version 1.
			byte[] versionData = new byte[] {0, 0, 1, 0 };

			destinationStream.Write(versionData);
			destinationStream.Flush();
		}
	}
}
;