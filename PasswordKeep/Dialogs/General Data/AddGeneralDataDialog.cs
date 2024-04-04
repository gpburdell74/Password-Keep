using Adaptive.Intelligence.Shared.UI;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides a dialog for adding a new General Data object to the user's list.
	/// </summary>
	/// <seealso cref="AdaptiveDialogBase" />
	public partial class AddGeneralDataDialog : AdaptiveDialogBase
	{
		#region Private Member Declarations
		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="AddGeneralDataDialog"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public AddGeneralDataDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (!IsDisposed && disposing)
			{
				components?.Dispose();
			}

			components = null;
			base.Dispose(disposing);
		}
		#endregion
	}
}
