using Adaptive.Intelligence.Shared.UI;
using PasswordKeep.Ops;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides the UI grid control for viewing and editing the general data entries.
	/// </summary>
	/// <seealso cref="AdaptiveControlBase" />
	public partial class GeneralDataControl : AdaptiveControlBase
	{
		#region Public Events        
		/// <summary>
		/// Occurs when the content on the grid is changed.
		/// </summary>
		public event EventHandler? Changed;
		#endregion

		#region Private Member Declarations
		/// <summary>
		/// The data content to be edited / displayed.
		/// </summary>
		private GeneralDataCollection? _data;
		#endregion

		#region Constructor / Dispose Methods        
		/// <summary>
		/// Initializes a new instance of the <see cref="GeneralDataControl"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public GeneralDataControl()
		{
			InitializeComponent();
		}
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">
		/// true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (!IsDisposed && disposing)
			{
				components?.Dispose();
			}

			components = null;
			_data = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Public Properties		
		/// <summary>
		/// Gets or sets the reference to the data source.
		/// </summary>
		/// <value>
		/// A <see cref="GeneralDataCollection"/> containing the data to be displayed.
		/// </value>
		public GeneralDataCollection? DataSource
		{
			get
			{
				return _data;
			}
			set
			{
				_data = value;
				DsProvider.DataSource = _data;
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
			DataGrid.DataMemberChanged += HandleGridDataMemberChanged;
			DataGrid.DataError += HandleGridDataError;
			DataGrid.RowsAdded += HandleGridRowsAdded;

			DataGrid.CellClick += HandleGridCellClicked;
			DataGrid.CellDoubleClick += HandleGridCellDoubleClicked;

			ActionBar.AddClicked += HandleAddButtonClicked;
			ActionBar.EditClicked += HandleEditButtonClicked;
			ActionBar.RemoveClicked += HandleRemoveButtonClicked;
		}
		/// <summary>
		/// Removes the event handlers for the controls on the dialog.
		/// </summary>
		protected override void RemoveEventHandlers()
		{
			DataGrid.DataMemberChanged -= HandleGridDataMemberChanged;
			DataGrid.DataError -= HandleGridDataError;
			DataGrid.RowsAdded -= HandleGridRowsAdded;

			DataGrid.CellClick -= HandleGridCellClicked;
			DataGrid.CellDoubleClick -= HandleGridCellDoubleClicked;

			ActionBar.AddClicked -= HandleAddButtonClicked;
			ActionBar.EditClicked -= HandleEditButtonClicked;
			ActionBar.RemoveClicked -= HandleRemoveButtonClicked;
		}
		/// <summary>
		/// Initializes the control and dialog state according to the form data.
		/// </summary>
		protected override void InitializeDataContent()
		{
			NameCol.DefaultCellStyle = new DataGridViewCellStyle();
			NameCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		}
		/// <summary>
		/// When implemented in a derived class, sets the display state for the controls on the dialog based on
		/// current conditions.
		/// </summary>
		/// <remarks>
		/// This is called by <see cref="M:Adaptive.Intelligence.Shared.UI.AdaptiveControlBase.SetState" /> after <see cref="M:Adaptive.Intelligence.Shared.UI.AdaptiveControlBase.SetSecurityState" /> is called.
		/// </remarks>
		protected override void SetDisplayState()
		{
			bool itemSelected = DataGrid.SelectedRows.Count > 0 || DataGrid.CurrentRow != null;

			ActionBar.EditEnabled = itemSelected;
			ActionBar.RemoveEnabled = itemSelected;
		}
		/// <summary>
		/// Sets the state of the UI controls before the data content is loaded.
		/// </summary>
		protected override void SetPreLoadState()
		{
			Cursor = Cursors.WaitCursor;
			DataGrid.Enabled = false;
			ActionBar.Enabled = false;
			Application.DoEvents();
			SuspendLayout();
		}
		/// <summary>
		/// Sets the state of the UI controls after the data content is loaded.
		/// </summary>
		protected override void SetPostLoadState()
		{
			Cursor = Cursors.Default;
			DataGrid.Enabled = true;
			ActionBar.Enabled = true;
			ResumeLayout();
		}
		#endregion

		#region Private Event Handlers		
		/// <summary>
		/// Handles the event when a new grid row is added.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">
		/// The <see cref="DataGridViewRowsAddedEventArgs"/> instance containing the event data.
		/// </param>
		private void HandleGridRowsAdded(object? sender, DataGridViewRowsAddedEventArgs e)
		{
			DataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
		/// <summary>
		/// Handles the event when a grid data error occurs.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		private void HandleGridDataError(object? sender, DataGridViewDataErrorEventArgs e)
		{
			e.Cancel = true;
		}
		/// <summary>
		/// Handles the event when a grid data member changes.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleGridDataMemberChanged(object? sender, EventArgs e)
		{
			Changed?.Invoke(this, e);
			SetState();
		}
		/// <summary>
		/// Handles the event when a grid cell is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
		private void HandleGridCellClicked(object? sender, DataGridViewCellEventArgs e)
		{
			SetPreLoadState();
			if (e.ColumnIndex > 0)
			{
				DataGridViewLinkColumn? column = DataGrid.Columns[e.ColumnIndex] as DataGridViewLinkColumn;
				if (column != null)
				{
					string value = (string)DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
					if (!string.IsNullOrEmpty(value))
					{
						if (!value.ToLower().StartsWith("http"))
							value = "http://" + value;

						OSUtilities.StartBrowser(value);
					}
				}
			}
			SetState();
			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when a grid cell is double-clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
		private void HandleGridCellDoubleClicked(object? sender, DataGridViewCellEventArgs e)
		{
			SetPreLoadState();
			SetState();
			DataGridViewLinkColumn? column = DataGrid.Columns[e.ColumnIndex] as DataGridViewLinkColumn;
			if (column != null)
			{
				UrlEditDialog dialog = new UrlEditDialog();
				dialog.UrlValue = (string)DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					column.UseColumnTextForLinkValue = false;
					DataGrid[e.ColumnIndex, e.RowIndex].Value = dialog.UrlValue;
					DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dialog.UrlValue;
				}
				dialog.Dispose();
			}
			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when the Add button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleAddButtonClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();
			AddGeneralDataDialog dialog = new AddGeneralDataDialog();
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK && dialog.Data != null)
			{
				GeneralData newItem = dialog.Data;
				_data?.Add(newItem);
				DataGrid.DataSource = _data;
				Invalidate();
			}
			dialog.Dispose();
			SetState();
			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when the Edit button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleEditButtonClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();

			SetPostLoadState();
		}
		/// <summary>
		/// Handles the event when the Remove button is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void HandleRemoveButtonClicked(object? sender, EventArgs e)
		{
			SetPreLoadState();

			SetPostLoadState();
		}
		#endregion
	}
}
