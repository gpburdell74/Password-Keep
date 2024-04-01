using Adaptive.Intelligence.Shared.UI;
using PasswordKeep.Ops;

namespace PasswordKeep.UI
{
	/// <summary>
	/// Provides the UI grid control for viewing and editing the General Login entries.
	/// </summary>
	/// <seealso cref="AdaptiveControlBase" />
	public partial class GeneralLoginControl : AdaptiveControlBase
    {
		#region Public Events        
		/// <summary>
		/// Occurs when the data content is changed.
		/// </summary>
		public event EventHandler? Changed;
		#endregion

		#region Private Data Members        
		/// <summary>
		/// The data content.
		/// </summary>
		private GeneralLoginCollection? _data;
		#endregion

		#region Constructor / Dispose Methods        
		/// <summary>
		/// Initializes a new instance of the <see cref="GeneralLoginControl"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public GeneralLoginControl()
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
			_data = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the reference to the data source.
		/// </summary>
		/// <value>
		/// The <see cref="GeneralLoginCollection"/> instance containing the data for the data source.
		/// </value>
		public GeneralLoginCollection? DataSource
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
		}
		/// <summary>
		/// Sets the state of the UI controls before the data content is loaded.
		/// </summary>
		protected override void SetPreLoadState()
		{
			Cursor = Cursors.WaitCursor;
		}
		/// <summary>
		/// Sets the state of the UI controls after the data content is loaded.
		/// </summary>
		protected override void SetPostLoadState()
		{
			Cursor = Cursors.Default;

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
		}
		/// <summary>
		/// Handles the event when a grid cell is clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
		private void HandleGridCellClicked(object? sender, DataGridViewCellEventArgs e)
		{
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
		}
		/// <summary>
		/// Handles the event when a grid cell is double-clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
		private void HandleGridCellDoubleClicked(object? sender, DataGridViewCellEventArgs e)
		{
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
		}
		#endregion
	}
}
