using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.IO
{
    /// <summary>
    /// Provides the signature definition for implmenting a safe reader object that tracks its own exceptions.
    /// </summary>
    /// <seealso cref="IExceptionTracking" />
    public interface ISafeReader : IExceptionTracking
    {
        #region Writing Methods        
        /// <summary>
        /// Reads a boolean value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/> value that was read, or <b>false</b> on failure.
        /// </returns>
        bool ReadBoolean();
        /// <summary>
        /// Reads a <see cref="DateTime"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="DateTime"/> value that was read, or <b>false</b> on failure.
        /// </returns>
        DateTime ReadDateTime();
        /// <summary>
        /// Reads a <see cref="DateTime"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="DateTime"/> value that was read, or <b>null</b>.
        /// </returns>
        DateTime? ReadDateTimeNullable();
        /// <summary>
        /// Reads a <see cref="int"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> value that was read, or <b>false</b> on failure.
        /// </returns>
        int ReadInt32();
        /// <summary>
        /// Reads a <see cref="int"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> value that was read, or <b>null</b>>.
        /// </returns>
        int? ReadInt32Nullable();
        /// <summary>
        /// Reads a NULL value indicator.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the NULL indicator field indicates NULL; otherwise, returns <b>false</b>.
        /// </returns>
        bool ReadNullIndicator();
        /// <summary>
        /// Reads a <see cref="USPhoneNumber"/> instace from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="USPhoneNumber"/> instace that was read, or <b>null</b>.
        /// </returns>
        USPhoneNumber? ReadPhoneNumber();
        /// <summary>
        /// Reads a <see cref="float"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="float"/> value that was read, or <b>false</b> on failure.
        /// </returns>
        float ReadSingle();
        /// <summary>
        /// Reads a <see cref="float"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="float"/> value that was read, or <b>null</b>.
        /// </returns>
        float? ReadSingleNullable();
        /// <summary>
        /// Reads a <see cref="string"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> value that was read, or <b>null</b>.
        /// </returns>
        string? ReadString();
        /// <summary>
        /// Reads a <see cref="AdaptiveStringCollection"/> value from the data source.
        /// </summary>
        /// <returns>
        /// The <see cref="AdaptiveStringCollection"/> value that was read, or <b>null</b>.
        /// </returns>
        AdaptiveStringCollection? ReadStringList();
        #endregion
    }
}
