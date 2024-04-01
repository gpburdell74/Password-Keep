using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.IO
{
    /// <summary>
    /// Provides the signature definition for implmenting a safe writer object that tracks its own exceptions.
    /// </summary>
    /// <seealso cref="IExceptionTracking" />
    public interface ISafeWriter : IExceptionTracking 
    {
		#region Properties        
		/// <summary>
		/// Gets the refernece to the base stream the writer is acting on.
		/// </summary>
		/// <value>
		/// The <see cref="Stream"/> implementation the writer is using.
		/// </value>
		Stream? BaseStream { get; }
		#endregion

		#region Writing Methods        
		/// <summary>
		/// Flushes the content of the buffer to the data source.
		/// </summary>
		/// <returns>
		/// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		bool Flush();
        /// <summary>
        /// Writes the specified <see cref="bool"/> value to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="bool"/> value to be written.
        /// </param>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(bool value);
        /// <summary>
        /// Writes the specified <see cref="DateTime"/> value to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="DateTime"/> value to be written.
        /// </param>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(DateTime value);
        /// <summary>
        /// Writes the specified <see cref="DateTime"/> value or NULL to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="DateTime"/> value to be written, or <b>null</b>.
        /// </param>
        /// <remarks>
        /// This method will write a NULL indicator value before the data value.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(DateTime? value);
        /// <summary>
        /// Writes the specified <see cref="int"/> value to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="int"/> value to be written.
        /// </param>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(int value);
        /// <summary>
        /// Writes the specified <see cref="int"/> value or NULL to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="int"/> value to be written, or <b>null</b>.
        /// </param>
        /// <remarks>
        /// This method will write a NULL indicator value before the data value.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(int? value);
        /// <summary>
        /// Writes the specified <see cref="float"/> value to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="float"/> value to be written.
        /// </param>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(float value);
        /// <summary>
        /// Writes the specified <see cref="float"/> value or NULL to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="float"/> value to be written, or <b>null</b>.
        /// </param>
        /// <remarks>
        /// This method will write a NULL indicator value before the data value.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(float? value);
        /// <summary>
        /// Writes the specified <see cref="string"/> value or NULL to the data source.
        /// </summary>
        /// <param name="value">
        /// The <see cref="string"/> value to be written, or <b>null</b>.
        /// </param>
        /// <remarks>
        /// This method will write a NULL indicator value before the data value.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(string value);
        /// <summary>
        /// Writes the contents of the specified <see cref="AdaptiveStringCollection"/> value or NULL to the data source.
        /// </summary>
        /// <param name="list">
        /// The <see cref="AdaptiveStringCollection"/> list whose contents are to be written, or <b>null</b>.
        /// </param>
        /// <remarks>
        /// This method will write a NULL indicator value before the data value.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(AdaptiveStringCollection? list);
        /// <summary>
        /// Writes the contents of the specified <see cref="USPhoneNumber"/> value or NULL to the data source.
        /// </summary>
        /// <param name="phoneNumber">
        /// The <see cref="USPhoneNumber"/> instance to be written, or <b>null</b>.
        /// </param>
        /// <remarks>
        /// This method will write a NULL indicator value before the data value.
        /// </remarks>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool Write(USPhoneNumber? phoneNumber);
        /// <summary>
        /// Writes the null indicator.
        /// </summary>
        /// <param name="isNull">
        /// <b>true</b> if the data value is NULL; otherwise, <b>false</b>.
        /// </param>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool WriteNullIndicator(bool isNull);
        #endregion

        #region Methods / Functions        
        /// <summary>
        /// Disconencts the current object from the underlying stream without closing or
        /// disposing of the underlying stream instance.
        /// </summary>
        void ReleaseStream();
        #endregion

    }
}
