namespace PasswordKeep.Data.Interfaces
{
	/// <summary>
	/// Provides the signature definition for cryptographic objects that check security key compatibility with one another.
	/// </summary>
	public interface ICryptoCompatibleObject
	{
		/// <summary>
		/// Validates that the current instance and the specified instance are using the same cryptographic keys and algorithms
		/// in order to with with each other.
		/// </summary>
		/// <param name="compareInstance">
		/// The <see cref="ICryptoCompatibleObject"/> implementation instance to compare to the current instance.
		/// </param>
		/// <returns>
		/// <b>true</b> if the two objects utilize the same cryptographic algorithms and keys; otherwise, <b>false</b>.
		/// </returns>
		bool ValidateCompatible(ICryptoCompatibleObject? compareInstance);
		/// <summary>
		/// Validates the primary key data.
		/// </summary>
		/// <param name="keyData">
		/// A byte array containing the key data.</param>
		/// <returns>
		/// <b>true</b> if the specified key data can be / is used by the instance.
		/// </returns>
		bool ValidatePrimaryKeyData(byte[] keyData);
		/// <summary>
		/// Validates the secondary key data.
		/// </summary>
		/// <param name="keyData">
		/// A byte array containing the key data.</param>
		/// <returns>
		/// <b>true</b> if the specified key data can be / is used by the instance.
		/// </returns>
		bool ValidateSecondaryKeyData(byte[] keyData);
		/// <summary>
		/// Validates the tertiary key data.
		/// </summary>
		/// <param name="keyData">
		/// A byte array containing the key data.</param>
		/// <returns>
		/// <b>true</b> if the specified key data can be / is used by the instance.
		/// </returns>
		bool ValidateTertiaryKeyData(byte[] keyData);

	}
}
