using Adaptive.Intelligence.Shared.UI;
using System.ComponentModel;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides the dialog used when logging in to a file.
	/// </summary>
	/// <seealso cref="AdaptiveDialogBase" />
	public partial class FileLoginDialog : AdaptiveDialogBase
	{
		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="FileLoginDialog"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public FileLoginDialog()
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

		#region Public Properties				
		/// <summary>
		/// Gets or sets the password value.
		/// </summary>
		/// <value>
		/// A string containing the value.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Password
		{
			get => PasswordText.Text;
			set
			{
				PasswordText.Text = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets the user ID / name value.
		/// </summary>
		/// <value>
		/// A string containing the value.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string UserId
		{
			get => NameText.Text;
			set
			{
				NameText.Text = value;
				Invalidate();
			}
		}
		#endregion

		#region Protected Method Overrides		
		/// <summary>
		/// Assigns the event handlers for the controls on the dialog.
		/// </summary>
		protected override void AssignEventHandlers()
		{
			OkButton.Click += HandleOkClicked;
			CloseButton.Click += HandleCloseClicked;

			NameText.TextChanged += HandleGenericControlChange;
			PasswordText.TextChanged += HandleGenericControlChange;
		}
		/// <summary>
		/// Removes the event handlers for the controls on the dialog.
		/// </summary>
		protected override void RemoveEventHandlers()
		{
			OkButton.Click -= HandleOkClicked;
			CloseButton.Click -= HandleCloseClicked;

			NameText.TextChanged -= HandleGenericControlChange;
			PasswordText.TextChanged -= HandleGenericControlChange;
		}
		protected override void InitializeDataContent()
		{
			// TODO: Remove this later.
			NameText.Text = "Sam Jones";
			PasswordText.Text = "7329.Wnyhiq";
		}
		/// <summary>
		/// When implemented in a derived class, sets the display state for the controls on the dialog based on
		/// current conditions.
		/// </summary>
		/// <remarks>
		/// This is called by <see cref="M:Adaptive.Intelligence.Shared.UI.AdaptiveDialogBase.SetState" /> after <see cref="M:Adaptive.Intelligence.Shared.UI.AdaptiveDialogBase.SetSecurityState" /> is called.
		/// </remarks>
		protected override void SetDisplayState()
		{
			ErrorProvider.Clear();

			if (NameText.Text.Length == 0)
				ErrorProvider.SetError(NameText, "You must enter a name value here.");
			else if (PasswordText.Text.Length == 0)
				ErrorProvider.SetError(PasswordText, "You must enter the password for the file here.");
			else
				OkButton.Enabled = true;
		}
		/// <summary>
		/// Sets the state of the UI controls before the data content is loaded.
		/// </summary>
		protected override void SetPreLoadState()
		{
			Cursor = Cursors.WaitCursor;
			OkButton.Enabled = false;
			CloseButton.Enabled = false;
			NameText.Enabled = false;
			PasswordText.Enabled = false;
			Application.DoEvents();
			SuspendLayout();
		}
		/// <summary>
		/// Sets the state of the UI controls after the data content is loaded.
		/// </summary>
		protected override void SetPostLoadState()
		{
			Cursor = Cursors.Default;
			OkButton.Enabled = true;
			CloseButton.Enabled = true;
			NameText.Enabled = true;
			PasswordText.Enabled = true;
			ResumeLayout();
		}
		#endregion

		#region Private Event Handlers		
		/// <summary>
		/// Handles the event when the OK button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleOkClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			DialogResult = DialogResult.OK;
			Close();
		}
		/// <summary>
		/// Handles the event when the Cancel button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleCloseClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			DialogResult = DialogResult.Cancel;
			Close();
		}
		#endregion
	}
}
