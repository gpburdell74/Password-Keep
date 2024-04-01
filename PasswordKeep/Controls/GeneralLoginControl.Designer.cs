namespace PasswordKeep.UI
{
    partial class GeneralLoginControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			ActionPanel = new Panel();
			DataGrid = new DataGridView();
			DsProvider = new BindingSource(components);
			NameCol = new DataGridViewTextBoxColumn();
			ServiceDescCol = new DataGridViewTextBoxColumn();
			DescCol = new DataGridViewTextBoxColumn();
			UrlCol = new DataGridViewLinkColumn();
			UserIdCol = new DataGridViewTextBoxColumn();
			PasswordCol = new DataGridViewTextBoxColumn();
			EmailCol = new DataGridViewTextBoxColumn();
			MfaCol = new DataGridViewCheckBoxColumn();
			MfaNoCol = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).BeginInit();
			SuspendLayout();
			// 
			// ActionPanel
			// 
			ActionPanel.Dock = DockStyle.Bottom;
			ActionPanel.Location = new Point(0, 633);
			ActionPanel.Name = "ActionPanel";
			ActionPanel.Size = new Size(1002, 32);
			ActionPanel.TabIndex = 0;
			// 
			// DataGrid
			// 
			DataGrid.AllowDrop = true;
			DataGrid.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = Color.AliceBlue;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = Color.Black;
			DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGrid.AutoGenerateColumns = false;
			DataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.Navy;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.White;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGrid.Columns.AddRange(new DataGridViewColumn[] { NameCol, ServiceDescCol, DescCol, UrlCol, UserIdCol, PasswordCol, EmailCol, MfaCol, MfaNoCol });
			DataGrid.DataSource = DsProvider;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.White;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle4.ForeColor = Color.Black;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
			DataGrid.DefaultCellStyle = dataGridViewCellStyle4;
			DataGrid.Dock = DockStyle.Fill;
			DataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
			DataGrid.EnableHeadersVisualStyles = false;
			DataGrid.Location = new Point(0, 0);
			DataGrid.MultiSelect = false;
			DataGrid.Name = "DataGrid";
			DataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = Color.Navy;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.75F);
			dataGridViewCellStyle5.ForeColor = Color.White;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
			DataGrid.RowHeadersWidth = 25;
			DataGrid.Size = new Size(1002, 633);
			DataGrid.TabIndex = 1;
			// 
			// DsProvider
			// 
			DsProvider.DataSource = typeof(Ops.GeneralLogin);
			// 
			// NameCol
			// 
			NameCol.DataPropertyName = "Name";
			NameCol.HeaderText = "Name";
			NameCol.Name = "NameCol";
			NameCol.Width = 150;
			// 
			// ServiceDescCol
			// 
			ServiceDescCol.DataPropertyName = "ServiceDescription";
			ServiceDescCol.HeaderText = "ServiceDescription";
			ServiceDescCol.Name = "ServiceDescCol";
			ServiceDescCol.Width = 150;
			// 
			// DescCol
			// 
			DescCol.DataPropertyName = "Description";
			DescCol.HeaderText = "Description";
			DescCol.Name = "DescCol";
			DescCol.Width = 150;
			// 
			// UrlCol
			// 
			UrlCol.ActiveLinkColor = Color.Blue;
			UrlCol.DataPropertyName = "Url";
			UrlCol.HeaderText = "Url";
			UrlCol.Name = "UrlCol";
			UrlCol.Resizable = DataGridViewTriState.True;
			UrlCol.SortMode = DataGridViewColumnSortMode.Automatic;
			UrlCol.Width = 200;
			// 
			// UserIdCol
			// 
			UserIdCol.DataPropertyName = "UserId";
			UserIdCol.HeaderText = "UserId";
			UserIdCol.Name = "UserIdCol";
			// 
			// PasswordCol
			// 
			PasswordCol.DataPropertyName = "Password";
			PasswordCol.HeaderText = "Password";
			PasswordCol.Name = "PasswordCol";
			// 
			// EmailCol
			// 
			EmailCol.DataPropertyName = "AssociatedEmail";
			EmailCol.HeaderText = "AssociatedEmail";
			EmailCol.Name = "EmailCol";
			// 
			// MfaCol
			// 
			MfaCol.DataPropertyName = "MFAActive";
			MfaCol.HeaderText = "MFAActive";
			MfaCol.Name = "MfaCol";
			// 
			// MfaNoCol
			// 
			MfaNoCol.DataPropertyName = "MFAPhoneNumber";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			MfaNoCol.DefaultCellStyle = dataGridViewCellStyle3;
			MfaNoCol.HeaderText = "MFAPhoneNumber";
			MfaNoCol.Name = "MfaNoCol";
			// 
			// GeneralLoginControl
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(DataGrid);
			Controls.Add(ActionPanel);
			Margin = new Padding(4, 5, 4, 5);
			Name = "GeneralLoginControl";
			Size = new Size(1002, 665);
			((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)DsProvider).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel ActionPanel;
        private DataGridView DataGrid;
        private BindingSource DsProvider;
		private DataGridViewTextBoxColumn NameCol;
		private DataGridViewTextBoxColumn ServiceDescCol;
		private DataGridViewTextBoxColumn DescCol;
		private DataGridViewLinkColumn UrlCol;
		private DataGridViewTextBoxColumn UserIdCol;
		private DataGridViewTextBoxColumn PasswordCol;
		private DataGridViewTextBoxColumn EmailCol;
		private DataGridViewCheckBoxColumn MfaCol;
		private DataGridViewTextBoxColumn MfaNoCol;
	}
}
