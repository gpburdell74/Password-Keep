using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
	/// <summary>
	/// Represents a data source record for an Identity Service drop-down selection.
	/// </summary>
	/// <remarks>
	/// This is used to allow a user selection of an <see cref="IdentityService"/> enumerated value from
	///  a data grid drop-down.
	/// </remarks>
	public sealed class IdentityServiceSelection : DisposableObjectBase
	{
		#region Private Member Declarations		
		/// <summary>
		/// The converter instance.
		/// </summary>
		private IdentityServiceConverter _converter;
		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="IdentityServiceSelection"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public IdentityServiceSelection()
		{
			_converter = new IdentityServiceConverter();
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
		/// Gets the display name for the selected service.
		/// </summary>
		/// <value>
		/// A string containing the display name for the <see cref="Service"/> value.
		/// </value>
		public string Name
		{
			get
			{
				return _converter.Convert(Service);
			}
		}
		/// <summary>
		/// Gets or sets the sleected service type.
		/// </summary>
		/// <value>
		/// The selected <see cref="IdentityService"/> enumerated value.
		/// </value>
		public IdentityService Service { get; set; }
		#endregion
	}
}
