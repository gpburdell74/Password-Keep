using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
	/// <summary>
	/// Represents a data source record for an Identity Service drop-down selection.
	/// </summary>
	/// <remarks>
	/// This is used to allow a user selection of an <see cref="FinancialAccount"/> enumerated value from
	///  a data grid drop-down.
	/// </remarks>
	public sealed class FinancialAccountSelection : DisposableObjectBase
	{
		#region Private Member Declarations		
		/// <summary>
		/// The converter instance.
		/// </summary>
		private FinancialAccountTypeConverter? _converter;
		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="FinancialAccountSelection"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public FinancialAccountSelection()
		{
			_converter = new FinancialAccountTypeConverter();
		}
		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
		/// <b>false</b> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			_converter = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the selected financial account type.
		/// </summary>
		/// <value>
		/// The selected <see cref="FinancialAccountType"/> enumerated value.
		/// </value>
		public FinancialAccountType AccountType { get; set; }
		/// <summary>
		/// Gets the display name for the selected service.
		/// </summary>
		/// <value>
		/// A string containing the display name for the <see cref="AccountType"/> value.
		/// </value>
		public string Name
		{
			get
			{
				if (_converter == null)
					return string.Empty;
				else
					return _converter.Convert(AccountType);
			}
		}
		#endregion
	}
}
