using Adaptive.Intelligence.Shared.UI;
using System.ComponentModel;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides a simple control for containing Add, Edit, and Delete buttons.
	/// </summary>
	/// <seealso cref="Adaptive.Intelligence.Shared.UI.AdaptiveControlBase" />
	public partial class AddEditRemoveToolbar : AdaptiveControlBase
	{
		#region Public Events		
		/// <summary>
		/// Occurs when the Add button is clicked.
		/// </summary>
		public event EventHandler AddClicked;
		/// <summary>
		/// Occurs when the Edit button is clicked.
		/// </summary>
		public event EventHandler EditClicked;
		/// <summary>
		/// Occurs when the Remove button is clicked.
		/// </summary>
		public event EventHandler RemoveClicked;
		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="AddEditRemoveToolbar"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public AddEditRemoveToolbar()
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
		/// Gets or sets a value indicating whether the Add button is visible.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Add button is visible; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Appearance"),
		 DefaultValue(true),
		 Description("Makes the Add button visible or invisible.")]
		public bool AddVisible
		{
			get => AddButton.Visible;

			set
			{
				AddButton.Visible = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Add button is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Add button is enabled; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Behavior"),
		 DefaultValue(true),
		 Description("Determines if the Add button is enabled or disabled.")]
		public bool AddEnabled
		{
			get => AddButton.Enabled;

			set
			{
				AddButton.Enabled = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Edit button is visible.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Edit button is visible; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Appearance"),
		 DefaultValue(true),
		 Description("Makes the Add button visible or invisible.")]
		public bool EditVisible
		{
			get => EditButton.Visible;

			set
			{
				EditButton.Visible = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Edit button is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Edit button is enabled; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Behavior"),
		 DefaultValue(true),
		 Description("Determines if the Add button is enabled or disabled.")]
		public bool EditEnabled
		{
			get => EditButton.Enabled;

			set
			{
				EditButton.Enabled = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Remove button is visible.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Remove button is visible; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Appearance"),
		 DefaultValue(true),
		 Description("Makes the Remove button visible or invisible.")]
		public bool RemoveVisible
		{
			get => RemoveButton.Visible;

			set
			{
				RemoveButton.Visible = value;
				Invalidate();
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Remove button is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if the Remove button is enabled; otherwise, <c>false</c>.
		/// </value>
		[Browsable(true),
		 Category("Behavior"),
		 DefaultValue(true),
		 Description("Determines if the Remove button is enabled or disabled.")]
		public bool RemoveEnabled
		{
			get => RemoveButton.Enabled;

			set
			{
				RemoveButton.Enabled = value;
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
			AddButton.Click += HandleAddClicked;
			EditButton.Click += HandleEditClicked;
			RemoveButton.Click += HandleRemoveClicked;
		}
		/// <summary>
		/// Removes the event handlers for the controls on the dialog.
		/// </summary>
		protected override void RemoveEventHandlers()
		{
			AddButton.Click -= HandleAddClicked;
			EditButton.Click -= HandleEditClicked;
			RemoveButton.Click -= HandleRemoveClicked;
		}
		#endregion

		#region Private Event Methods		
		/// <summary>
		/// Raises the <see cref="E:AddClicked" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnAddClicked(EventArgs e)
		{
			AddClicked?.Invoke(this, e);
		}
		/// <summary>
		/// Raises the <see cref="E:EditClicked" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnEditClicked(EventArgs e)
		{
			EditClicked?.Invoke(this, e);
		}
		/// <summary>
		/// Raises the <see cref="E:RemoveClicked" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnRemoveClicked(EventArgs e)
		{
			RemoveClicked?.Invoke(this, e);
		}
		#endregion

		#region Private Event Handlers		
		/// <summary>
		/// Handles the event when the Add button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleAddClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			OnAddClicked(e);
			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when the Edit button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleEditClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			OnEditClicked(e);
			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when the REmove button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleRemoveClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			OnRemoveClicked(e);
			SetPostLoadState();
		}
		#endregion
	}
}
