using Adaptive.Intelligence.Shared.UI;
using System.ComponentModel;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides the dialog for specifying the parameters for creating a new file.
	/// </summary>
	/// <seealso cref="AdaptiveDialogBase" />
	public partial class NewFileDialog : AdaptiveDialogBase
	{
		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="NewFileDialog"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public NewFileDialog()
		
		#endregion

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

		#region Public Properties		
		/// <summary>
		/// Gets or sets the path and name of the file.
		/// </summary>
		/// <value>
		/// A string containing the fully-qualified path and name of the file.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string? FileName
		{
			get => FileNameText.Text;
			set
			{
				FileNameText.Text = value;
				Invalidate();
			}

		}
		/// <summary>
		/// Gets or sets the value of the password entry.
		/// </summary>
		/// <value>
		/// A string containing the file password value.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string? PasswordValue
		{
			get => PasswordText.Text;
			set
			{
				PasswordText.Text = value; 
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets the path and name of the file.
		/// </summary>
		/// <value>
		/// A string containing the fully-qualified path and name of the file.
		/// </value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string? UserName
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
			EllipseButton.Click += HandleElipseClicked;

			FileNameText.TextChanged += HandleGenericControlChange;
			NameText.TextChanged += HandleGenericControlChange;
			PasswordText.TextChanged += HandleGenericControlChange;
			ConfirmText.TextChanged += HandleGenericControlChange;
		}
		/// <summary>
		/// Removes the event handlers for the controls on the dialog.
		/// </summary>
		protected override void RemoveEventHandlers()
		{
			OkButton.Click -= HandleOkClicked;
			CloseButton.Click -= HandleCloseClicked;
			EllipseButton.Click -= HandleElipseClicked;

			FileNameText.TextChanged += HandleGenericControlChange;
			NameText.TextChanged += HandleGenericControlChange;
			PasswordText.TextChanged += HandleGenericControlChange;
			ConfirmText.TextChanged += HandleGenericControlChange;
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
			bool canSave = false;

			ErrorProvider.Clear();

			if (FileNameText.Text.Length == 0)
				ErrorProvider.SetError(FileNameText, "You must specify a save file path and name.");

			else if (NameText.Text.Length == 0)
				ErrorProvider.SetError(NameText, "You must enter a name value to help secure this file.");

			else if (PasswordText.Text.Length == 0)
				ErrorProvider.SetError(PasswordText, "You must enter a password value to help secure this file.");

			else if (ConfirmText.Text != PasswordText.Text)
				ErrorProvider.SetError(NameText, "The passwords you have entered do not match.");
			else
				canSave = true;

			OkButton.Enabled = canSave;
		}
		/// <summary>
		/// Sets the state of the UI controls before the data content is loaded.
		/// </summary>
		protected override void SetPreLoadState()
		{
			Cursor = Cursors.WaitCursor;
			OkButton.Enabled = false;
			CloseButton.Enabled = false;
			EllipseButton.Enabled = false;
			NameText.Enabled = false;
			FileNameText.Enabled = false;
			PasswordText.Enabled = false;
			ConfirmText.Enabled = false;
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
			EllipseButton.Enabled = true;
			NameText.Enabled = true;
			FileNameText.Enabled = true;
			PasswordText.Enabled = true;
			ConfirmText.Enabled = true;
			ResumeLayout();
			SetState();
		}
		#endregion

		#region Private Event Handlers		
		/// <summary>
		/// Handles the event when the Close/Cancel button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleCloseClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			DialogResult = DialogResult.Cancel;
			Close();
		}
		/// <summary>
		/// Handles the event when the Ellipsis button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleElipseClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			SaveFileDialog dialog = DialogProvider.CreateSaveFileDialog();
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				FileNameText.Text = dialog.FileName;
			}
			dialog.Dispose();
			SetPostLoadState();
		}
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
		#endregion

	}
}
