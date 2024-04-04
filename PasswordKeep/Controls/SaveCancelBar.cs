using Adaptive.Intelligence.Shared.UI;
using System.ComponentModel;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides a common action bar with Save/OK and Cancel/Close buttons.
	/// </summary>
	/// <seealso cref="AdaptiveControlBase" />
	public partial class SaveCancelBar : AdaptiveControlBase
	{
		#region Public Events		
		/// <summary>
		/// Occurs when the Cancel/Close button is clicked.
		/// </summary>
		public event EventHandler CancelClicked;
		/// <summary>
		/// Occurs when the Save button is clicked.
		/// </summary>
		public event EventHandler SaveClicked;
		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="SaveCancelBar"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public SaveCancelBar()
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
		/// Gets or sets a value indicating whether the Cancel/Close button is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Cancel/Close button is enabled; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Behavior"),
			Description("Enables or disables the Cancel/Close button.")]
		public bool CancelEnabled
		{
			get => CloseButton.Enabled;
			set
			{
				CloseButton.Enabled = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets the text displayed on the Cancel/Close button.
		/// </summary>
		/// <value>
		/// A string containing the text to be displayed.
		/// </value>
		[Browsable(true),
		 Category("Appearance"),
		 Description("The text to be displayed on the button.")]
		public string CancelText
		{
			get => CloseButton.Text;
			set
			{
				CloseButton.Text = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Cancel/Close button is visible.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Cancel/Close button is visible; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Appearance"),
			Description("Shows or hides the Cancel/Close button.")]
		public bool CancelVisible
		{
			get => CloseButton.Visible;
			set
			{
				CloseButton.Visible = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Save button is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Save button is enabled; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Behavior"),
		 Description("Enables or disables the Save button.")]
		public bool SaveEnabled
		{
			get => SaveButton.Enabled;
			set
			{
				SaveButton.Enabled = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets the text displayed on the Save button.
		/// </summary>
		/// <value>
		/// A string containing the text to be displayed.
		/// </value>
		[Browsable(true),
		 Category("Appearance"),
		 Description("The text to be displayed on the button.")]
		public string SaveText
		{
			get => SaveButton.Text;
			set
			{
				SaveButton.Text = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Save button is visible.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Save button is visible; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Appearance"),
			Description("Shows or hides the Save button.")]
		public bool SaveVisible
		{
			get => SaveButton.Visible;
			set
			{
				SaveButton.Visible = value;
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
			CloseButton.Click += HandleCloseClicked;
			SaveButton.Click += HandleSaveClicked;
		}
		/// <summary>
		/// Removes the event handlers for the controls on the dialog.
		/// </summary>
		protected override void RemoveEventHandlers()
		{
			CloseButton.Click -= HandleCloseClicked;
			SaveButton.Click -= HandleSaveClicked;
		}
		#endregion

		#region Private Event Methods		
		/// <summary>
		/// Raises the <see cref="E:CancelClicked" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnCancelClicked(EventArgs e)
		{
			CancelClicked?.Invoke(this, e);
		}
		/// <summary>
		/// Raises the <see cref="E:SaveClicked" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnSaveClicked(EventArgs e)
		{
			SaveClicked?.Invoke(this, e);
		}
		#endregion

		#region Private Event Handlers		
		/// <summary>
		/// Handles the event when the Cancel/Close button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleCloseClicked(object? sender, EventArgs e)
		{
			OnCancelClicked(e);
		}
		/// <summary>
		/// Handles the event when the Save button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleSaveClicked(object? sender, EventArgs e)
		{
			OnSaveClicked(e);
		}
		#endregion
	}
}