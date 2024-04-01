namespace PasswordKeep.Ops
{
	/// <summary>
	/// Provides constants definitions for various file operations.
	/// </summary>
	public static class FileConstants
	{
		/// <summary>
		/// The file extension for Password Keep Clear Text Files.
		/// </summary>
		public const string ExtensionClearFile = ".pkf";
		/// <summary>
		/// The file extension for Password Keep Secure Files.
		/// </summary>
		public const string ExtensionSecureFile = ".pksf";

		/// <summary>
		/// The dialog file filter text for reading or writing Secure Files.
		/// </summary>
		public const string FilterSecureFile = "Password Keep Files (*.pksf)|*.pksf";
		/// <summary>
		/// The dialog file filter text for reading or writing Secure or Clear Text Files.
		/// </summary>
		public const string FilterSecureAndClearFile = "Password Keep Files (*.pksf)|*.pksf|Password Keep Clear Files (*.pkf)|*.pkf";
	}
}
